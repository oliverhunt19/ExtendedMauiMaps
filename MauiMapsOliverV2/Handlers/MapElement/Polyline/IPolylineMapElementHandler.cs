using Microsoft.Maui.Maps.Handlers;


#if __IOS__ || MACCATALYST
using PlatformView = MapKit.IMKAnnotation;
#elif ANDROID
using Android.Gms.Maps;
using PlatformView = MauiMapsOliverV2.Platforms.Android.MapElements.MauiMapPolyline;
#elif WINDOWS
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace MauiMapsOliverV2.Handlers.MapElement
{
    public interface IPolylineMapElementHandler : IMapElementHandler
    {
    }
}
