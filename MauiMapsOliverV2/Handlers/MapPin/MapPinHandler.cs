#if __IOS__ || MACCATALYST
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using ExtendedMauiMaps.Platforms.iOS.MapElements;
using PlatformView = ExtendedMauiMaps.Platforms.iOS.MapElements.MauiMapMarker;
#elif ANDROID
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using ExtendedMauiMaps.Platforms.Android.MapElements;
using PlatformView = ExtendedMauiMaps.Platforms.Android.MapElements.MauiMapMarker;
#elif WINDOWS
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class MapPinHandler : IMapPinHandler
	{
		public static IPropertyMapper<IMapPin, IMapPinHandler> Mapper = new PropertyMapper<IMapPin, IMapPinHandler>(ElementMapper)
		{
			[nameof(IMapPin.Location)] = MapLocation,
			[nameof(IMapPin.Label)] = MapLabel,
			[nameof(IMapPin.Address)] = MapAddress,
			[nameof(IMapPin.AnchorV)] = MapAnchor,
			[nameof(IMapPin.AnchorU)] = MapAnchor,
			[nameof(IMapPin.InfoWindowAnchorU)] = SetRotation,
			[nameof(IMapPin.InfoWindowAnchorV)] = SetRotation,
			[nameof(IMapPin.PinRotation)] = SetRotation,
			[nameof(IMapPin.Flatten)] = SetRotation,
			
		};

		public MapPinHandler() : base(Mapper)
		{

		}

		public MapPinHandler(IPropertyMapper? mapper = null)
		: base(mapper ?? Mapper)
		{
		}

		IMapPin IMapPinHandler.VirtualView => VirtualView;

		PlatformView IMapPinHandler.PlatformView => PlatformView;
	}
}
