using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Platforms.Windows.MapElements;

namespace ExtendedMauiMaps.Handlers.MapElement.Polyline
{
    public partial class PolylineMapElementHandler : StrokeMapElementHandler<IPolylineMapElement, MauiMapPolyline>
    {
        protected override MauiMapPolyline CreateElement()
        {
            throw new NotImplementedException();
        }

        private static void UpdateGeopath(PolylineMapElementHandler handler, IPolylineMapElement element)
        {
            //handler.PlatformView.Points = element.Geopath.Select(x => new LatLng(x.Latitude, x.Longitude)).ToList();
        }
    }
}
