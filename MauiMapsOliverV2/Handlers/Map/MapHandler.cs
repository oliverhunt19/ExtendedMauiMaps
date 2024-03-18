#if __IOS__ || MACCATALYST
using PlatformView = Microsoft.Maui.Maps.Platform.MauiMKMapView;
#elif MONOANDROID || ANDROID
using PlatformView = Android.Gms.Maps.MapView;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.FrameworkElement;
#elif TIZEN
using PlatformView = Tizen.NUI.BaseComponents.View;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif
using Microsoft.Maui.Handlers;
using System.Collections.Specialized;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class MapHandler : IMapHandler
	{
		public static IPropertyMapper<IMap, IMapHandler> Mapper = new PropertyMapper<IMap, IMapHandler>(ViewHandler.ViewMapper)
		{
			[nameof(IMap.MapType)] = MapMapType,
			[nameof(IMap.IsShowingUser)] = MapIsShowingUser,
			[nameof(IMap.IsScrollEnabled)] = MapIsScrollEnabled,
			[nameof(IMap.IsTrafficEnabled)] = MapIsTrafficEnabled,
			[nameof(IMap.IsZoomEnabled)] = MapIsZoomEnabled,
		};


		public static CommandMapper<IMap, IMapHandler> CommandMapper = new(ViewCommandMapper)
		{
			[nameof(IMap.MoveToRegion)] = MapMoveToRegion,
			[nameof(IMapHandler.UpdateMapElement)] = MapUpdateMapElement,
			[nameof(IMapHandler.ElementsCollectionChanged)] = MapElementsCollectionChanged

        };

        

        public MapHandler() : base(Mapper, CommandMapper)
		{

		}

		public MapHandler(IPropertyMapper? mapper = null, CommandMapper? commandMapper = null)
		: base(mapper ?? Mapper, commandMapper ?? CommandMapper)
		{
		}

		IMap IMapHandler.VirtualView => VirtualView;

		PlatformView IMapHandler.PlatformView => PlatformView;

		private static void MapUpdateMapElement(IMapHandler handler, IMap map, object? arg)
		{
			if (arg is not MapElementHandlerUpdateProperty args)
				return;

			handler.UpdateMapElement(args.MapElement, args.e);
		}

        private static void MapElementsCollectionChanged(IMapHandler handler, IMap map, object? arg3)
        {
            if(arg3 is not NotifyCollectionChangedEventArgs e)
            {
                return;
            }

            handler.ElementsCollectionChanged(e);
        }

        
    }
}
