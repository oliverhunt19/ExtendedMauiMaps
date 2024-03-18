using Android.Gms.Maps.Model;
using MauiMapsOliverV2.Handlers.MapElement;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;
using Microsoft.Maui.Maps.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class CircleMapElementHandler : FilledMapElementHandler<ICircleMapElement, CircleOptions>
    {

        protected override CircleOptions CreateElement()
        {
            ICircleMapElement circleMap = VirtualView;
            return new CircleOptions().InvokeCenter(circleMap.Center.ToALatLng())
                .InvokeRadius(circleMap.Radius.Meters);//.InvokeStrokePattern(new List<PatternItem>());
        }

        protected override CircleOptions SetClickable(CircleOptions platformView, bool clickable)
        {
            return platformView.Clickable(clickable);
        }

        protected override CircleOptions SetFill(CircleOptions circleOptions, SolidPaint? fill)
        {
            if(fill is null)
            {
                return circleOptions;
            }
            circleOptions.InvokeFillColor(fill.Color.AsColor());
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
