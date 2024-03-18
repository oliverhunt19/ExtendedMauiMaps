using MapKit;
using MauiMapsOliverV2.Core;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolygonMapElementHandler : FilledMapElementHandler<IPolygonMapElement, MKPolygon>
    {
        protected override MKPolygon CreateElement()
        {
            throw new NotImplementedException();
        }

        protected override MKPolygon SetClickable(MKPolygon platformView, bool clickable)
        {
            throw new NotImplementedException();
        }

        protected override MKPolygon SetFill(MKPolygon platformView, SolidPaint? fill)
        {
            throw new NotImplementedException();
        }

        protected override MKPolygon SetStroke(MKPolygon platformView, SolidPaint? fill)
        {
            throw new NotImplementedException();
        }

        protected override MKPolygon SetStrokeThickness(MKPolygon circleOptions, float? width)
        {
            throw new NotImplementedException();
        }
    }
}
