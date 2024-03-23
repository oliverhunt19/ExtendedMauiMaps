using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Polygon;

namespace Microsoft.Maui.Maps.Handlers
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
