#if __IOS__ || MACCATALYST
using Microsoft.Maui.Handlers;
using PlatformView = MapKit.MKOverlayRenderer;
#elif MONOANDROID
using PlatformView = Java.Lang.Object;
#elif WINDOWS
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using MauiMapsOliverV2.Platforms.Android.MapElements;
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Maps.Handlers
{
    public abstract partial class MapElementHandler<TVirtualView, TPlatformView> : IMapElementHandler
        where TPlatformView : class, IMauiMapElement
        where TVirtualView : class, IMapElement
    {
		public static IPropertyMapper<IMapStrokeElement, IMapElementHandler> Mapper = new PropertyMapper<IMapStrokeElement, IMapElementHandler>(ElementMapper)
		{
			//[nameof(IMapStrokeElement.Stroke)] = MapStroke,
			//[nameof(IMapStrokeElement.StrokeThickness)] = MapStrokeThickness,
//			[nameof(IFilledMapElement.Fill)] = MapFill,
//#if MONOANDROID
//			["Geopath"] = MapGeopath,
//			[nameof(ICircleMapElement.Radius)] = MapRadius,
//			[nameof(ICircleMapElement.Center)] = MapCenter,
//#endif
		};


		public MapElementHandler() : base(Mapper)
		{

		}

		public MapElementHandler(IPropertyMapper? mapper = null)
		: base(mapper ?? Mapper)
		{
		}

        

        protected abstract TPlatformView CreateElement();

        protected override TPlatformView CreatePlatformElement()
        {
            return CreateElement();
        }
        


        
    }
}
