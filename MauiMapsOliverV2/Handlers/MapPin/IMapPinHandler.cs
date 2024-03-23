#if __IOS__ || MACCATALYST
using PlatformView = MauiMapsOliverV2.Platforms.iOS.MapElements.MauiMapMarker;
#elif ANDROID
using Android.Gms.Maps;
using PlatformView = MauiMapsOliverV2.Platforms.Android.MapElements.MauiMapMarker;
#elif WINDOWS
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Maps.Handlers
{
    public interface IMapPinHandler : IElementHandler
	{
		new IMapPin VirtualView { get; }
		new PlatformView PlatformView { get; }
	}
}
