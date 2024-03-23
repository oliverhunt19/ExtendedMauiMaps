using Android.Gms.Maps;
using ExtendedMauiMaps.Core;
using GeneralUtils;
using MauiMapsOliverV2.IMauiMapElements;
using Microsoft.Maui.Platform;
using System.Diagnostics;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal abstract class ElementManager<TAndroid, TAndroidOptions, TMapElement>
        where TAndroid : Java.Lang.Object
        where TAndroidOptions : class
        where TMapElement : IMapElement
    {
        protected readonly Func<IMauiContext?> GetMauiContext;

        protected readonly Func<GoogleMap> GetGoogleMap;

        private readonly Mapper<TMapElement, TAndroid> _mapAndroidMapper;


        protected ElementManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map)
        {
            GetMauiContext = mauiContext;
            GetGoogleMap = map;

            _mapAndroidMapper = new Mapper<TMapElement, TAndroid>();
        }

        protected bool ElementClicked(TAndroid android)
        {
            var pin = _mapAndroidMapper[android];

            if(pin == null)
            {
                return false;
            }

            // Setting e.Handled = true will prevent the info window from being presented
            // SendMarkerClick() returns the value of PinClickedEventArgs.HideInfoWindow
            bool handled = pin.SendElementClick();
            return handled;
        }

        public void ClearAll()
        {
            foreach(var a in _mapAndroidMapper)
            {
                ClearElementOnMainThread(a.Value);
            }
            _mapAndroidMapper.Clear();
        }

        protected abstract void ClearElement(TAndroid nativeElement);

        /// <summary>
        /// This is here to enfore that the remove is done on the main thread
        /// </summary>
        /// <param name="nativeElement"></param>
        private void ClearElementOnMainThread(TAndroid nativeElement)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ClearElement(nativeElement);
            });

        }

        public void RemoveElement(TMapElement element)
        {
            TAndroid? android = GetNativeFromElement(element);
            if(android == null)
            {
                return;
            }

            ClearElementOnMainThread(android);
            _mapAndroidMapper.Remove(element);
        }


        public void AddElement(TMapElement element)
        {
            AddMapElement(element);
        }

        /// <summary>
        /// This adds the map element to the map
        /// </summary>
        /// <param name="mapElement"></param>
        private void AddMapElement(TMapElement mapElement)
        {
            try
            {
                GoogleMap map = GetGoogleMap.Invoke();
                if(map == null)
                {
                    return;
                }

                IMauiContext? mauiContext = GetMauiContext.Invoke();
                if(mauiContext == null)
                {
                    return;
                }

                MauiMapElement<TAndroid>? options = mapElement.ToHandler(mauiContext)?.PlatformView as MauiMapElement<TAndroid>;
                if(options != null)
                {
                    // This is done so that the addition is done on the main thread
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        TAndroid nativeElement = options.AddToMap(map);

                        mapElement.MapElementId = GetNativeID(nativeElement);
                        _mapAndroidMapper.Add(mapElement, nativeElement);
                    });
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }

        
        protected TAndroid? GetNativeFromElement(TMapElement polygon)
        {
            return _mapAndroidMapper[polygon];
        }

        protected TMapElement GetMapElementFromNative(TAndroid native)
        {
            return _mapAndroidMapper[native];
        }

        /// <summary>
        /// Gets the Id fron the Android Native Element
        /// </summary>
        /// <param name="nativeElement"></param>
        /// <returns></returns>
        protected abstract string GetNativeID(TAndroid nativeElement);

    }
}
