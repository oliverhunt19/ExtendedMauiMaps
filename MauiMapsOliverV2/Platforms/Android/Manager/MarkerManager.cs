using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Core;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal class MarkerManager : ElementManager<Marker, MarkerOptions, IMapPin>
    {
        private Func<IEnumerable<IMapPin>> GetMapPins;
        public MarkerManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IEnumerable<IMapPin>> mapPins) : base(mauiContext, map, mapPins)
        {
            GetMapPins = mapPins;
        }

        public void OnMarkerClick(object? sender, GoogleMap.MarkerClickEventArgs e)
        {
            e.Handled = ElementClicked(e.Marker);
        }

        public void OnInfoWindowClick(object? sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var marker = e.Marker;
            var pin = GetElementFromNative(marker, GetMapPins.Invoke());

            if(pin == null)
            {
                return;
            }

            pin.SendElementClick();

            // SendInfoWindowClick() returns the value of PinClickedEventArgs.HideInfoWindow
            bool hideInfoWindow = pin.SendInfoWindowClick();
            if(hideInfoWindow)
            {
                marker.HideInfoWindow();
            }
        }

        public void Map_MarkerDrag(object? sender, GoogleMap.MarkerDragEventArgs e)
        {

        }

        public void Map_MarkerDragEnd(object? sender, GoogleMap.MarkerDragEndEventArgs e)
        {

        }

        public void Map_MarkerDragStart(object? sender, GoogleMap.MarkerDragStartEventArgs e)
        {

        }

        //protected override Marker AddElement(MarkerOptions options)
        //{
        //    return GetGoogleMap.Invoke().AddMarker(options);
        //}

        protected override string GetNativeID(Marker nativeElement)
        {
            return nativeElement.Id;
        }

        protected override void ClearElement(Marker nativeElement)
        {
            nativeElement.Remove();
        }

        //protected override void UpdateAndroidElement(IMapPin mapElement, Marker androideleent, PropertyChangedEventArgs e)
        //{
        //    e.UpdateElement((x) => androideleent.Position = x, mapElement.Location.ToALatLng(), nameof(IMapPin.Location));
        //    e.UpdateElement((x) => androideleent.Snippet = x, mapElement.Address, nameof(IMapPin.Address));
        //    e.UpdateElement((x) => androideleent.Title = x, mapElement.Label, nameof(IMapPin.Label));
        //    e.UpdateElement((x) => androideleent.Rotation = x, (float) mapElement.PinRotation, nameof(IMapPin.PinRotation));
        //    e.UpdateElement((x) => androideleent.Flat = x, mapElement.Flatten, nameof(IMapPin.Flatten));
        //    e.UpdateElement((x) =>
        //    {
        //        IMauiContext? mauiContext = GetMauiContext.Invoke();
        //        if(mauiContext is not null)
        //        {
        //            x.LoadImage(mauiContext, result =>
        //            {
        //                if(result?.Value is BitmapDrawable bitmapDrawable)
        //                {
        //                    androideleent.SetIcon(BitmapDescriptorFactory.FromBitmap(bitmapDrawable.Bitmap));
        //                }
        //            });
        //        }
        //    }
        //    , mapElement.ImageSource, nameof(IMapPin.ImageSource));


        //}
    }
}
