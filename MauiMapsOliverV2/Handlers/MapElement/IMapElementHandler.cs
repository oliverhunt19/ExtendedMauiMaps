#if __IOS__ || MACCATALYST
using ExtendedMauiMaps.Handlers.MapElement;
using Microsoft;
using Microsoft.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using PlatformView = MapKit.MKOverlayRenderer;
#elif MONOANDROID
using Android.Gms.Maps;
using Android.OS;
using Android.Runtime;
using PlatformView = Java.Lang.Object;
#elif WINDOWS
using ExtendedMauiMaps.Handlers.MapElement;
using Microsoft;
using Microsoft.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using ExtendedMauiMaps.Handlers.MapElement;
using Microsoft;
using Microsoft.Maui;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using PlatformView = System.Object;
#endif

namespace ExtendedMauiMaps.Handlers.MapElement
{
    public interface IMapElementHandler : IElementHandler
    {
        //new IMapElement VirtualView { get; }
        //new PlatformView PlatformView { get; }
    }
}
