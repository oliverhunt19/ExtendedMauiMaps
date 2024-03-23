using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement;
using ExtendedMauiMaps.Platforms.Android.MapElements;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolylineMapElementHandler : StrokeMapElementHandler<IPolylineMapElement, MauiMapPolyline>
    {

        protected override MauiMapPolyline CreateElement()
        {
            return new MauiMapPolyline();
        }

        private static void UpdateGeopath(PolylineMapElementHandler handler, IPolylineMapElement element)
        {
            handler.PlatformView.Points = element.Geopath.Select(x=> new LatLng(x.Latitude,x.Longitude)).ToList();
        }
    }
}
