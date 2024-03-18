using Android.Gms.Maps.Model;
using MauiMapsOliverV2.Platforms.Android.MapElements;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Maps.Platform;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class CircleMapElementHandler : FilledMapElementHandler<ICircleMapElement, MauiMapCircle>
    {

        protected override MauiMapCircle CreateElement()
        {
            ICircleMapElement circleMap = VirtualView;
            return new CircleOptions().InvokeCenter(circleMap.Center.ToALatLng())
                .InvokeRadius(circleMap.Radius.Meters);//.InvokeStrokePattern(new List<PatternItem>());
        }

        protected override MauiMapCircle SetClickable(MauiMapCircle platformView, bool clickable)
        {
            return platformView. (clickable);
        }

        protected override MauiMapCircle SetFill(MauiMapCircle circleOptions, SolidPaint? fill)
        {
            if(fill is null)
            {
                return circleOptions;
            }
            circleOptions.FillColor = fill.Color.AsColor();
            return circleOptions;
        }


        protected override CircleOptions SetStroke(CircleOptions platformView, SolidPaint? fill)
        {
            if (fill is null)
            {
                return platformView;
            }
            return platformView.InvokeStrokeColor(fill.Color.AsColor());
        }

        protected override CircleOptions SetStrokeThickness(CircleOptions circleOptions, float? width)
        {
            if (width is null)
            {
                return circleOptions;
            }
            return circleOptions.InvokeStrokeWidth(width.Value);
        }

    }
}
