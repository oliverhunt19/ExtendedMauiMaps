using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Core;
using APolygon = Android.Gms.Maps.Model.Polygon;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal class PolygonManager : StrokeElementManager<APolygon, PolygonOptions, IPolygonMapElement>
    {
        public PolygonManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IEnumerable<IPolygonMapElement>> mapElementClicked) : base(mauiContext, map, mapElementClicked)
        {
        }

        public void Map_PolygonClick(object? sender, GoogleMap.PolygonClickEventArgs e)
        {
            ShapeClicked(e.Polygon);
        }

        protected override void ClearElement(APolygon nativeElement)
        {
            nativeElement.Remove();
        }

        protected override ClickedPolyline GetClickedElement(APolygon element)
        {
            return new PolygonClicked(element);
        }

        protected override string GetNativeID(APolygon nativeElement)
        {
            return nativeElement.Id;
        }

        private class PolygonClicked : ClickedPolyline
        {
            public PolygonClicked(APolygon previous) : base(previous)
            {
            }

            protected override int GetColour(APolygon element)
            {
                return element.StrokeColor;
            }

            protected override void SetColour(APolygon element, int Colour)
            {
                element.StrokeColor = Colour;
            }
        }
    }
}
