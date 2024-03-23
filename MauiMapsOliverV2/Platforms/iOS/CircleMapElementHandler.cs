using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Circle;
using ExtendedMauiMaps.Handlers.MapElement.Filled;
using ExtendedMauiMaps.Platforms.iOS.MapElements;

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
