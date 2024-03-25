using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Filled;
using ExtendedMauiMaps.Platforms.Android;
using ExtendedMauiMaps.Platforms.Android.MapElements;

namespace ExtendedMauiMaps.Handlers.MapElement.Circle
{
    public partial class CircleMapElementHandler : FilledMapElementHandler<ICircleMapElement, MauiMapCircle>
    {

        protected override MauiMapCircle CreateElement()
        {
            return new MauiMapCircle();
        }

        public static void UpdateCircleRadius(CircleMapElementHandler handler, ICircleMapElement circleMapElement)
        {
            handler.PlatformView.Radius = circleMapElement.Radius.Meters;
        }

        private static void UpdateCircleCentre(CircleMapElementHandler handler, ICircleMapElement element)
        {
            handler.PlatformView.Center = element.Center.ToALatLng();
        }

    }
}
