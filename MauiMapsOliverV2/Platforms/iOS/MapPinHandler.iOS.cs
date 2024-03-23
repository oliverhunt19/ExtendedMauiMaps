﻿using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapPin;
using ExtendedMauiMaps.Platforms.iOS.MapElements;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class MapPinHandler : ElementHandler<IMapPin, MauiMapMarker>
	{
		protected override MauiMapMarker CreatePlatformElement() => new MauiMapMarker();

		public static void MapLocation(IMapPinHandler handler, IMapPin mapPin)
		{
				//handler.PlatformView.Position = new CLLocationCoordinate2D(mapPin.Location.Latitude, mapPin.Location.Longitude);
		}

		public static void MapLabel(IMapPinHandler handler, IMapPin mapPin)
		{

            handler.PlatformView.Title = mapPin.Label;
				
			
		}

		public static void MapAddress(IMapPinHandler handler, IMapPin mapPin)
		{
				handler.PlatformView.Snippet = mapPin.Address;
		}


        public static void SetRotation(IMapPinHandler handler, IMapPin mapPin)
        {
            //handler.PlatformView.Rotation = (float) mapPin.PinRotation;
        }

        public static void MapAnchor(IMapPinHandler handler, IMapPin pin)
        {
            //handler.PlatformView.Anchor = ((float) pin.AnchorU, (float) pin.AnchorV);
        }

        public static void MapZIndex(IMapPinHandler handler, IMapPin pin)
        {
            // Not impleemted Yet
            //handler.PlatformView.ZIndex = pin.ZIndex;
        }

        public static void MapPinDraggable(IMapPinHandler handler, IMapPin pin)
        {
            // Not impleemted Yet
            //handler.PlatformView.Draggable = pin.Dra;
        }

        public static void MapPinAlpha(IMapPinHandler handler, IMapPin pin)
        {
            // Not impleemted Yet
            //handler.PlatformView.Alpha = pin.;
        }

        public static void MapPinVisible(IMapPinHandler handler, IMapPin pin)
        {
            // Not impleemted Yet
            //handler.PlatformView.Visible = pin.ZIndex;
        }

        public static void MapPinInfoWindowAnchor(IMapPinHandler handler, IMapPin pin)
        {
            //handler.PlatformView.InfoWindowAnchor = ((float) pin.InfoWindowAnchorU, (float) pin.InfoWindowAnchorV);
        }

        public static void MapPinFlatten(IMapPinHandler handler, IMapPin pin)
        {
            //handler.PlatformView.Flatten = pin.Flatten;

        }


        public static void MapPinIcon(IMapPinHandler handler, IMapPin pin)
        {

        }
    }
}
