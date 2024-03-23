//#if __IOS__ || MACCATALYST
//using Microsoft.Maui.Handlers;
//using PlatformView = MapKit.MKOverlayRenderer;
//#elif MONOANDROID
//using PlatformView = Java.Lang.Object;
//#elif WINDOWS
//using PlatformView = System.Object;
//#elif TIZEN
//using PlatformView = System.Object;
//#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
//using MauiMapsOliverV2.IMauiMapElements;
//using MauiMapsOliverV2.Platforms.Android.MapElements;
//using Microsoft.Maui.Handlers;
//using PlatformView = System.Object;
//#endif

using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement;
using ExtendedMauiMaps.IMauiMapElements;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Maps.Handlers
{
    public abstract partial class MapElementHandler<TVirtualView, TPlatformView> : ElementHandler<TVirtualView, TPlatformView>, IMapElementHandler
        where TPlatformView : class, IMauiMapElement
        where TVirtualView : class, IMapElement
    {
		public static IPropertyMapper<IMapStrokeElement, IMapElementHandler> Mapper = new PropertyMapper<IMapStrokeElement, IMapElementHandler>(ElementMapper)
		{

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
