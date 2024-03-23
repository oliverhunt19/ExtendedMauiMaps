using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Core;
using APolyline = Android.Gms.Maps.Model.Polyline;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal class PolylineManager : StrokeElementManager<APolyline, PolylineOptions, IPolylineMapElement>
    {


        public PolylineManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map) : base(mauiContext, map)
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

        //protected override APolyline AddElement(PolylineOptions options)
        //{
        //    return GetGoogleMap.Invoke().AddPolyline(options);
        //}

        protected override void ClearElement(APolyline nativeElement)
        {
            nativeElement.Remove();
        }

        protected override ClickedPolyline GetClickedPolyline(APolyline element)
        {
            return new PolygonClicked(element);
        }

        //protected override void UpdateAndroidElement(IPolylineMapElement mapElement, APolyline androideleent, PropertyChangedEventArgs e)
        //{
        //    e.UpdateElement((x) => androideleent.Clickable = x, mapElement.IsClickable, nameof(IPolylineMapElement.IsClickable));
        //    e.UpdateElement((x) => androideleent.Color = x, (mapElement.Stroke as SolidPaint).Color.AsColor(), nameof(IPolylineMapElement.Stroke));
        //    e.UpdateElement((x) => androideleent.Width = x, (float) mapElement.StrokeThickness, nameof(IPolylineMapElement.StrokeThickness));
        //}

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
