using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Filled;
using ExtendedMauiMaps.Platforms.Android.MapElements;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolygonMapElementHandler : FilledMapElementHandler<IPolygonMapElement, MauiMapPolygon>
    {
        protected override MauiMapPolygon CreateElement()
        {
            return new MauiMapPolygon();
        }

        private static void UpdateGeopath(PolygonMapElementHandler handler, IPolygonMapElement element)
        {
            handler.PlatformView.Points = element.Geopath.Select(x=>new Android.Gms.Maps.Model.LatLng(x.Latitude,x.Longitude)).ToList();
        }


    }
}
