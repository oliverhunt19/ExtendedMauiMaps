using Android.Gms.Maps;
using GeneralUtils;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Platform;
using System.ComponentModel;
using System.Diagnostics;

namespace MauiMapsOliverV2.Platforms.Android.Manager
{
    internal abstract class ElementManager<TAndroid, TAndroidOptions, TMapElement>
        where TAndroid : Java.Lang.Object
        where TAndroidOptions : class
        where TMapElement : IMapElement
    {
        protected readonly Func<IMauiContext?> GetMauiContext;

        protected readonly Func<GoogleMap> GetGoogleMap;

        protected readonly Func<IEnumerable<TMapElement>> GetTMapElement;

        //public IMauiContext MauiContext;
        //public GoogleMap Map;

        //protected readonly List<TAndroid> _aPolylines;

        //protected readonly List<TMapElement> mapElements;

        protected readonly Mapper<TMapElement, TAndroid> MapAndroidMapper;


        protected ElementManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IEnumerable<TMapElement>> getMapElement)
        {
            GetTMapElement = getMapElement;
            GetMauiContext = mauiContext;
            GetGoogleMap = map;
            //_aPolylines = new List<TAndroid>();
            //mapElements = new List<TMapElement>();

            MapAndroidMapper = new Mapper<TMapElement, TAndroid>();
        }

        protected abstract TAndroid AddElement(TAndroidOptions options);
        


        protected bool ElementClicked(TAndroid android)
        {


            var pin = MapAndroidMapper[android];//GetElementFromNative(android, mapElements);

            if(pin == null)
            {
                return false;
            }

            // Setting e.Handled = true will prevent the info window from being presented
            // SendMarkerClick() returns the value of PinClickedEventArgs.HideInfoWindow
            bool handled = pin.SendElementClick();
            return handled;
        }


        //public void AddElements(IEnumerable<TMapElement> mapPins)
        //{
        //    ClearAll();
        //    foreach (var p in mapPins)
        //    {
        //        AddElement(p);

        //    }
        //}

        public void ClearAll()
        {
            foreach(var a in MapAndroidMapper)
            {
                ClearElementOnMainThread(a.Value);
            }
            MapAndroidMapper.Clear();
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
            MapAndroidMapper.Remove(element);
            //mapElements.Remove(element);
            //_aPolylines.Remove(android);
        }


        public void AddElement(TMapElement element)
        {
            AddPolyline(element);
        }

        private void AddPolyline(TMapElement polyline)
        {
            try
            {
                GoogleMap map = GetGoogleMap.Invoke();
                if (map == null)
                    return;
                IMauiContext? mauiContext = GetMauiContext.Invoke();
                var options = polyline.ToHandler(mauiContext!)?.PlatformView as TAndroidOptions;
                if (options != null)
                {
                    // This is done so that the addition is done on the main thread
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        var nativePolyline = AddElement(options);

                        polyline.MapElementId = GetNativeID(nativePolyline);

                        MapAndroidMapper.Add(polyline, nativePolyline);
                        //_aPolylines.Add(nativePolyline);
                        //mapElements.Add(polyline);
                    });
                    
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
            
        }

        public void ElementUpdated(TMapElement mapElement, PropertyChangedEventArgs e)
        {
            TAndroid? android = GetNativeFromElement(mapElement);
            if (android is null)
            {
                return;
            }

            UpdateAndroidElement(mapElement,android,e);
        }

        protected abstract void UpdateAndroidElement(TMapElement mapElement, TAndroid androideleent, PropertyChangedEventArgs e);

        protected TAndroid? GetNativeFromElement(TMapElement polygon)
        {
            return MapAndroidMapper[polygon];

            //if (polygon.MapElementId is string)
            //{
            //    for (int i = 0; i < MapAndroidMapper.Count; i++)
            //    {
            //        var native = _aPolylines[i];
            //        string id = GetNativeID(native);
            //        if (id == (string)polygon.MapElementId)
            //        {
            //            return native;
            //        }
            //    }
            //}
            //return default;
        }

        protected abstract string GetNativeID(TAndroid nativeElement);

        protected TElement? GetElementFromNative<TElement>(TAndroid mapElement, IEnumerable<TElement> mapElements)
            where TElement : IMapElement
        {
            string nativeID = GetNativeID(mapElement);
            int index = ElementIdsSameIndex(nativeID, mapElements);
            if (mapElements.ElementAt(index) is TElement element)
            {
                return element;
            }
            return default;
        }

        private static int ElementIdsSameIndex<T>(string Id, IEnumerable<T> mapElements)
            where T : IMapElement
        {
            for (int i = 0; i < mapElements.Count(); i++)
            {
                var pin = mapElements.ElementAt(i);
                if (pin?.MapElementId is string markerId)
                {
                    if (markerId == Id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }



    }
}
