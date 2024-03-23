using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Handlers.MapElement;
using MauiMapsOliverV2.Platforms.iOS.MapElements;

namespace Microsoft.Maui.Maps.Handlers
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
