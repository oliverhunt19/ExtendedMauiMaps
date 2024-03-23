using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Platforms.iOS.MapElements;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolygonMapElementHandler : FilledMapElementHandler<IPolygonMapElement, MauiMapPolygon>
    {
        protected override MauiMapPolygon CreateElement()
        {
            throw new NotImplementedException();
        }

        private static void UpdateGeopath(PolygonMapElementHandler handler, IPolygonMapElement element)
        {
            //handler.PlatformView.Points = element.Geopath.Select(x => new Android.Gms.Maps.Model.LatLng(x.Latitude, x.Longitude)).ToList();
        }
    }
}
