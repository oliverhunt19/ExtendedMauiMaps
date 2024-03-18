using Android.Gms.Maps.Model;
using Android.Graphics.Drawables;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Maps.Platform;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class MapPinHandler : ElementHandler<IMapPin, MarkerOptions>
	{

		public static void MapLocation(IMapPinHandler handler, IMapPin mapPin)
		{
			if (mapPin.Location != null)
				handler.PlatformView.SetPosition(new LatLng(mapPin.Location.Latitude, mapPin.Location.Longitude));
		}

		public static void MapLabel(IMapPinHandler handler, IMapPin mapPin)
		{
			handler.PlatformView.SetTitle(mapPin.Label);
		}

		public static void MapAddress(IMapPinHandler handler, IMapPin mapPin)
		{
			handler.PlatformView.SetSnippet(mapPin.Address);
		}

        protected override MarkerOptions CreatePlatformElement()
		{
			MarkerOptions markerOptions = new MarkerOptions().SetTitle(VirtualView.Label)
				.SetSnippet(VirtualView.Address)
				.SetPosition(VirtualView.Location.ToALatLng())
				.SetRotation((float) VirtualView.PinRotation).Flat(VirtualView.Flatten)
				.Anchor((float)VirtualView.AnchorU,(float)VirtualView.AnchorV)
				.InfoWindowAnchor((float)VirtualView.InfoWindowAnchorU, (float)VirtualView.InfoWindowAnchorV);
			if(MauiContext is not null)
			{
                VirtualView.ImageSource.LoadImage(MauiContext, result =>
                {
                    if(result?.Value is BitmapDrawable bitmapDrawable)
                    {
                        markerOptions.SetIcon(BitmapDescriptorFactory.FromBitmap(bitmapDrawable.Bitmap));
                    }
                });
            }
            
			return markerOptions;
		}
    }
}
