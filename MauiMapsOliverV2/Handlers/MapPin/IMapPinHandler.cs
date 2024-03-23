#if __IOS__ || MACCATALYST
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using ExtendedMauiMaps.Platforms.iOS.MapElements;
using Microsoft;
using Microsoft.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using PlatformView = ExtendedMauiMaps.Platforms.iOS.MapElements.MauiMapMarker;
#elif ANDROID
using Android.Gms.Maps;
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using ExtendedMauiMaps.Platforms.Android.MapElements;
using Microsoft;
using Microsoft.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using PlatformView = ExtendedMauiMaps.Platforms.Android.MapElements.MauiMapMarker;
#elif WINDOWS
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using Microsoft;
using Microsoft.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif


/* Unmerged change from project 'ExtendedMauiMaps (net8.0-windows10.0.19041.0)'
Before:
namespace Microsoft.Maui.Maps.Handlers
After:
namespace ExtendedMauiMaps.Handlers
*/

/* Unmerged change from project 'ExtendedMauiMaps (net8.0-android)'
Before:
namespace Microsoft.Maui.Maps.Handlers
After:
namespace ExtendedMauiMaps.Handlers
*/
namespace ExtendedMauiMaps.Handlers.MapPin
{
    public interface IMapPinHandler : IElementHandler
    {
        new IMapPin VirtualView { get; }
        new PlatformView PlatformView { get; }
    }
}
