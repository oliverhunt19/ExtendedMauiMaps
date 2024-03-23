using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Handlers.MapElement;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolygonMapElementHandler : IPolygonMapElementHandler
    {

        public static IPropertyMapper<IPolygonMapElement, PolygonMapElementHandler> PolygonMapper = new PropertyMapper<IPolygonMapElement, PolygonMapElementHandler>(ElementMapper)
        {
            [nameof(IPolygonMapElement.Geopath)] = UpdateGeopath,

        };

        
    }
}
