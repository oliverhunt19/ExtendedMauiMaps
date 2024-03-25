using ExtendedMauiMaps.Core;

namespace ExtendedMauiMaps.Handlers.MapElement.Polygon
{
    public partial class PolygonMapElementHandler : IPolygonMapElementHandler
    {

        public static IPropertyMapper<IPolygonMapElement, PolygonMapElementHandler> PolygonMapper = new PropertyMapper<IPolygonMapElement, PolygonMapElementHandler>(FilledMapMapper)
        {
            [nameof(IPolygonMapElement.Geopath)] = UpdateGeopath,

        };

        public PolygonMapElementHandler() : base(PolygonMapper)
        {

        }

        public PolygonMapElementHandler(IPropertyMapper? mapper = null)
        : base(mapper ?? PolygonMapper)
        {
        }


    }
}
