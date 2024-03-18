using Android.Gms.Maps.Model;
using MauiMapsOliverV2.Core;
using Microsoft.Maui.Graphics.Platform;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolygonMapElementHandler : FilledMapElementHandler<IPolygonMapElement, PolygonOptions>
    {
        protected override PolygonOptions CreateElement()
        {
            return new PolygonOptions().Add(VirtualView.Geopath.Select(x=>new LatLng(x.Latitude, x.Longitude)).ToArray());
        }

        protected override PolygonOptions SetClickable(PolygonOptions platformView, bool clickable)
        {
            return platformView.Clickable(clickable);
        }

        protected override PolygonOptions SetFill(PolygonOptions platformView, SolidPaint? fill)
        {
            if (fill is null)
            {
                return platformView;
            }
            return platformView.InvokeFillColor(fill.Color.AsColor());
        }

        protected override PolygonOptions SetStroke(PolygonOptions platformView, SolidPaint? fill)
        {
            if (fill is null)
            {
                return platformView;
            }
            return platformView.InvokeStrokeColor(fill.Color.AsColor());
        }

        protected override PolygonOptions SetStrokeThickness(PolygonOptions circleOptions, float? width)
        {
            return circleOptions.InvokeStrokeWidth((float) width);
        }
    }
}
