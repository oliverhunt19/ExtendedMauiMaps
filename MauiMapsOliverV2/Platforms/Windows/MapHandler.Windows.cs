﻿using ExtendedMauiMaps.Core;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml;
using System.Collections.Specialized;
using System.ComponentModel;
using IMap = ExtendedMauiMaps.Core.IMap;

namespace ExtendedMauiMaps.Handlers.Map
{
    public partial class MapHandler : ViewHandler<IMap, FrameworkElement>
	{

		protected override FrameworkElement CreatePlatformView() => throw new NotImplementedException();

		public static void MapMapType(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public static void MapIsZoomEnabled(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public static void MapIsScrollEnabled(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public static void MapIsTrafficEnabled(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public static void MapIsShowingUser(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public static void MapMoveToRegion(IMapHandler handler, IMap map, object? arg) => throw new NotImplementedException();

		public static void MapPins(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public static void MapElements(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public void UpdateMapElement(IMapElement element, PropertyChangedEventArgs e) => throw new NotImplementedException();

        public void ElementsCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
