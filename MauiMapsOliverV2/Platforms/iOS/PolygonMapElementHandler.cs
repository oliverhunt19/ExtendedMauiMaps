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
            //throw new NotImplementedException();
        }

    }
}
