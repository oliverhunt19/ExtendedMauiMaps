
using MapKit;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class CircleMapElementHandler : FilledMapElementHandler<ICircleMapElement, MKCircleRenderer>
    {
        protected override MKCircleRenderer CreateElement()
        {
            throw new NotImplementedException();
        }

        protected override MKCircleRenderer SetClickable(MKCircleRenderer platformView, bool clickable)
        {
            throw new NotImplementedException();
        }

        protected override MKCircleRenderer SetFill(MKCircleRenderer platformView, SolidPaint? fill)
        {
            throw new NotImplementedException();
        }

        protected override MKCircleRenderer SetStroke(MKCircleRenderer platformView, SolidPaint? fill)
        {
            throw new NotImplementedException();
        }

        protected override MKCircleRenderer SetStrokeThickness(MKCircleRenderer circleOptions, float? width)
        {
            throw new NotImplementedException();
        }

    }
}
