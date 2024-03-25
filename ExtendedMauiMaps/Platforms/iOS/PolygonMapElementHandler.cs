using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Filled;
using ExtendedMauiMaps.Platforms.iOS.MapElements;

namespace ExtendedMauiMaps.Handlers.MapElement.Polygon
{
    public partial class PolygonMapElementHandler : FilledMapElementHandler<IPolygonMapElement, MauiMapPolygon>
    {
        protected override MauiMapPolygon CreateElement()
        {
            throw new NotImplementedException();
        }

        private static void UpdateGeopath(PolygonMapElementHandler handler, IPolygonMapElement element)
        {
            //throw new NotImplementedException();
        }

    }
}
