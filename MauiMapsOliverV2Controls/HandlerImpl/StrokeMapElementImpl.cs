using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMapsOliverV2Controls
{
    public partial class StrokeMapElement : IMapStrokeElement
    {
        Paint? IStroke.Stroke => StrokeColor?.AsPaint();

        double IStroke.StrokeThickness => StrokeWidth;

        LineCap IStroke.StrokeLineCap => throw new NotImplementedException();

        LineJoin IStroke.StrokeLineJoin => throw new NotImplementedException();

        float[] IStroke.StrokeDashPattern => throw new NotImplementedException();

        float IStroke.StrokeDashOffset => throw new NotImplementedException();

        float IStroke.StrokeMiterLimit => throw new NotImplementedException();
    }
}
