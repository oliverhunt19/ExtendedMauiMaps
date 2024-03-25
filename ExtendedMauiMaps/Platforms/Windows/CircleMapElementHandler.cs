using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Filled;
using ExtendedMauiMaps.Platforms.Windows.MapElements;

namespace ExtendedMauiMaps.Handlers.MapElement.Circle
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
