using System.Collections.Specialized;

#if __IOS__ || MACCATALYST
using PlatformView = ExtendedMauiMaps.Platforms.iOS.MauiMKMapView;
#elif MONOANDROID || ANDROID
using Android.Gms.Maps;

using PlatformView = Android.Gms.Maps.MapView;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Tizen.NUI.BaseComponents.View;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

using IMap = ExtendedMauiMaps.Core.IMap;


/* Unmerged change from project 'ExtendedMauiMaps (net8.0-windows10.0.19041.0)'
Before:
namespace Microsoft.Maui.Maps.Handlers
After:
namespace ExtendedMauiMaps.Handlers.Map
*/

/* Unmerged change from project 'ExtendedMauiMaps (net8.0-android)'
Before:
namespace Microsoft.Maui.Maps.Handlers
After:
namespace Microsoft.Handlers.Map
*/
namespace ExtendedMauiMaps.Handlers.Map
{
    public interface IMapHandler : IViewHandler
    {
        new IMap VirtualView { get; }
        new PlatformView PlatformView { get; }
#if MONOANDROID || ANDROID
        GoogleMap? Map { get; }
#endif

        void ElementsCollectionChanged(NotifyCollectionChangedEventArgs e);
    }
}
