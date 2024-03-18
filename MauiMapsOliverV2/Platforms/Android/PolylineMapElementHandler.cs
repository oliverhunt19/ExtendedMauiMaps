using Android.Gms.Maps.Model;
using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Handlers.MapElement;
using Microsoft.Maui.Graphics.Platform;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolylineMapElementHandler : StrokeMapElementHandler<IPolylineMapElement, PolylineOptions>
    {

        protected override PolylineOptions CreateElement()
        {
            IPolylineMapElement circleMap = VirtualView;
            return new PolylineOptions().Add(circleMap.Geopath.Select(x=>new LatLng(x.Latitude, x.Longitude)).ToArray());
        }

        protected override PolylineOptions SetClickable(PolylineOptions platformView, bool clickable)
        {
            return platformView.Clickable(clickable);
        }

        protected override PolylineOptions SetStroke(PolylineOptions platformView, SolidPaint? fill)
        {
            if (fill is null)
            {
                return platformView;
            }
            return platformView.InvokeColor(fill.Color.AsColor());
        }

        protected override PolylineOptions SetStrokeThickness(PolylineOptions circleOptions, float? width)
        {
            if (width is null)
            {
                return circleOptions;
            }
            circleOptions.InvokeWidth(width.Value);
            return circleOptions;
        }

    }
}
