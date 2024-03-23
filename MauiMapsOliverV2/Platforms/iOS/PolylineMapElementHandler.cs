using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Platforms.iOS.MapElements;

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
            //handler.PlatformView.
        }

    }
}
