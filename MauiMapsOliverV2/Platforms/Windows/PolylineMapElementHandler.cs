using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Handlers.MapElement;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolylineMapElementHandler : StrokeMapElementHandler<IPolylineMapElement, object>
    {
        protected override object CreateElement()
        {
            throw new NotImplementedException();
        }

        protected override object SetClickable(object platformView, bool clickable)
        {
            throw new NotImplementedException();
        }

        protected override object SetStroke(object platformView, SolidPaint? fill)
        {
            throw new NotImplementedException();
        }

        protected override object SetStrokeThickness(object circleOptions, float? width)
        {
            throw new NotImplementedException();
        }
    }
}
