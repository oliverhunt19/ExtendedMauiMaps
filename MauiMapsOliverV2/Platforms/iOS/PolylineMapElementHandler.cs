using MapKit;
using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Handlers.MapElement;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolylineMapElementHandler : StrokeMapElementHandler<IPolylineMapElement, MKPolyline>
    {
        protected override MKPolyline CreateElement()
        {
            throw new NotImplementedException();
        }

        protected override MKPolyline SetClickable(MKPolyline platformView, bool clickable)
        {
            throw new NotImplementedException();
        }

        protected override MKPolyline SetStroke(MKPolyline platformView, SolidPaint? fill)
        {
            throw new NotImplementedException();
        }

        protected override MKPolyline SetStrokeThickness(MKPolyline circleOptions, float? width)
        {
            throw new NotImplementedException();
        }

    }
}
