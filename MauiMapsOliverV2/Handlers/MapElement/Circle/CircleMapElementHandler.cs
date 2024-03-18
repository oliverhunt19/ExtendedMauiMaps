using MauiMapsOliverV2.Handlers.MapElement;

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

        public static IPropertyMapper<IMapStrokeElement, IMapElementHandler> Mapper = new PropertyMapper<IMapStrokeElement, IMapElementHandler>(ElementMapper)
        {
            [nameof(IMapStrokeElement.Stroke)] = MapStroke,
            [nameof(IMapStrokeElement.StrokeThickness)] = MapStrokeThickness,
            //[nameof(IFilledMapElement.Fill)] = MapFill,
#if MONOANDROID
			["Geopath"] = MapGeopath,
			[nameof(ICircleMapElement.Radius)] = MapRadius,
			[nameof(ICircleMapElement.Center)] = MapCenter,
#endif
        };

        public CircleMapElementHandler() : base(Mapper)
        {

        }

        public CircleMapElementHandler(IPropertyMapper? mapper = null)
        : base(mapper ?? Mapper)
        {
        }

        





        //IMapElement IMapElementHandler.VirtualView => VirtualView;

        //PlatformView IMapElementHandler.PlatformView => PlatformView;
    }
}
