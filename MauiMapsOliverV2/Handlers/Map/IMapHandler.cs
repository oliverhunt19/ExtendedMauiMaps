#if __IOS__ || MACCATALYST
using MauiMapsOliverV2.Core;
using System.Collections.Specialized;
using System.ComponentModel;
using PlatformView = Microsoft.Maui.Maps.Platform.MauiMKMapView;
#elif MONOANDROID || ANDROID
using Android.Gms.Maps;
using MauiMapsOliverV2.Core;
using System.Collections.Specialized;
using System.ComponentModel;
using PlatformView = Android.Gms.Maps.MapView;
#elif WINDOWS
using System.Collections.Specialized;
using System.ComponentModel;
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Tizen.NUI.BaseComponents.View;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Maps.Handlers
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
