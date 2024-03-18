using Android.Gms.Maps.Model;
using MauiMapsOliverV2.Platforms.Android.MapElements;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class MapPinHandler : ElementHandler<IMapPin, MauiMapMarker>
	{

		public static void MapLocation(IMapPinHandler handler, IMapPin mapPin)
		{
			if (mapPin.Location != null)
				handler.PlatformView.Position = new LatLng(mapPin.Location.Latitude, mapPin.Location.Longitude);
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
			handler.PlatformView.Rotation = (float) mapPin.PinRotation;
		}

        public static void MapAnchor(IMapPinHandler handler, IMapPin pin)
        {
            handler.PlatformView.Anchor = ((float) pin.AnchorU, (float) pin.AnchorV);
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
            handler.PlatformView.InfoWindowAnchor = ((float)pin.InfoWindowAnchorU,(float)pin.InfoWindowAnchorV);
        }

		public static void MapPinFlatten(IMapPinHandler handler, IMapPin pin)
		{
			handler.PlatformView.Flatten = pin.Flatten;

        }


        public static void MapPinIcon(IMapPinHandler handler, IMapPin pin)
		{

		}

        protected override MauiMapMarker CreatePlatformElement()
		{
			//MarkerOptions markerOptions = new MarkerOptions().SetTitle(VirtualView.Label)
			//	.SetSnippet(VirtualView.Address)
			//	.SetPosition(VirtualView.Location.ToALatLng())
			//	.SetRotation((float) VirtualView.PinRotation)
			//	.Flat(VirtualView.Flatten)
			//	.Anchor((float)VirtualView.AnchorU,(float)VirtualView.AnchorV)
			//	.InfoWindowAnchor((float)VirtualView.InfoWindowAnchorU, (float)VirtualView.InfoWindowAnchorV);
			//if(MauiContext is not null)
			//{
			//             VirtualView.ImageSource.LoadImage(MauiContext, result =>
			//             {
			//                 if(result?.Value is BitmapDrawable bitmapDrawable)
			//                 {
			//                     markerOptions.SetIcon(BitmapDescriptorFactory.FromBitmap(bitmapDrawable.Bitmap));
			//                 }
			//             });
			//         }

			//return markerOptions;

			return new MauiMapMarker();
		}
    }
}
