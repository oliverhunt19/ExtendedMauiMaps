using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Core;
using APolyline = Android.Gms.Maps.Model.Polyline;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal class PolylineManager : StrokeElementManager<APolyline, PolylineOptions, IPolylineMapElement>
    {


        public PolylineManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IEnumerable<IPolylineMapElement>> geoPathElements) : base(mauiContext, map, geoPathElements)
        {
        }



        public void Map_PolylineClick(object? sender, GoogleMap.PolylineClickEventArgs e)
        {
            ShapeClicked(e.Polyline);
        }




        protected override string GetNativeID(APolyline nativeElement)
        {
            return nativeElement.Id;
        }


        protected override void ClearElement(APolyline nativeElement)
        {
            nativeElement.Remove();
        }

        protected override ClickedPolyline GetClickedElement(APolyline element)
        {
            return new PolygonClicked(element);
        }

        private class PolygonClicked : ClickedPolyline
        {
            public PolygonClicked(APolyline previous) : base(previous)
            {
            }

            protected override int GetColour(APolyline element)
            {
                return element.Color;
            }

            protected override void SetColour(APolyline element, int Colour)
            {
                element.Color = Colour;
            }
        }

    }










}
