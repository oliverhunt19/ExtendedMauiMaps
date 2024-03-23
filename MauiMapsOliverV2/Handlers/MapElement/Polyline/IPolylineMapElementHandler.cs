
/* Unmerged change from project 'ExtendedMauiMaps (net8.0-android)'
Before:
using ExtendedMauiMaps.Handlers.MapElement;



#if __IOS__ || MACCATALYST
After:
using ExtendedMauiMaps.Handlers.MapElement;
using MauiMapsOliverV2;
using MauiMapsOliverV2.Handlers;
using MauiMapsOliverV2.Handlers.MapElement;
using ExtendedMauiMaps.Handlers.MapElement.Polyline;




#if __IOS__ || MACCATALYST
*/
using ExtendedMauiMaps.Handlers.MapElement;





#if __IOS__ || MACCATALYST
using PlatformView = MapKit.IMKAnnotation;
#elif ANDROID
using Android.Gms.Maps;
using PlatformView = ExtendedMauiMaps.Platforms.Android.MapElements.MauiMapPolyline;
#elif WINDOWS
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace ExtendedMauiMaps.Handlers.MapElement.Polyline
{
    public interface IPolylineMapElementHandler : IMapElementHandler
    {
    }
}
