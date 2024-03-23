using MauiMapsOliverV2.Platforms.Android.MapElements;
using Microsoft.Maui.Maps.Platform;

namespace Microsoft.Maui.Maps.Handlers
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
