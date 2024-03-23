using MauiMapsOliverV2.Handlers.MapElement;
using MauiMapsOliverV2.Platforms.iOS.MapElements;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class CircleMapElementHandler : FilledMapElementHandler<ICircleMapElement, MauiMapCircle>
    {
        protected override MauiMapCircle CreateElement()
        {
            throw new NotImplementedException();
        }

        public static void UpdateCircleRadius(ICircleMapElementHandler handler, ICircleMapElement circleMapElement)
        {

        }

        private static void UpdateCircleCentre(CircleMapElementHandler handler, ICircleMapElement element)
        {
            throw new NotImplementedException();
        }

    }
}
