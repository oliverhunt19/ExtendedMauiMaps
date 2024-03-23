using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Circle;

#if __IOS__ || MACCATALYST
using PlatformView = MapKit.MKOverlayRenderer;
#elif MONOANDROID
using PlatformView = Java.Lang.Object;
#elif WINDOWS
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class CircleMapElementHandler : ICircleMapElementHandler
    {

        public static IPropertyMapper<ICircleMapElement, CircleMapElementHandler> CircleMapper = new PropertyMapper<ICircleMapElement, CircleMapElementHandler>(FilledMapMapper)
        {
            [nameof(ICircleMapElement.Center)] = UpdateCircleCentre,
            [nameof(ICircleMapElement.Radius)] = UpdateCircleRadius,
        };

        

        public CircleMapElementHandler() : base(CircleMapper)
        {

        }

        public CircleMapElementHandler(IPropertyMapper? mapper = null)
        : base(mapper ?? CircleMapper)
        {
        }
    }
}
