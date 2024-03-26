using ExtendedMauiMaps.IMauiMapElements;
using MapKit;

namespace ExtendedMauiMaps.Platforms.iOS.MapElements
{
    public class MauiMapPolygon : MauiFilledMapElement<MKPolygonRenderer>
    {
        public override bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override float ZIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string Id => throw new NotImplementedException();

        public override Color FillColour { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override bool Clickable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Color StrokeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double StrokeWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private void SetColour()
        {
            if(Element is not null)
                Element.FillColor = UIKit.UIColor.FromRGBA(255,255,255, 255);
        }

        protected override MKPolygonRenderer AddToMapsInternal(MKMapView mapView)
        {
            MKPolygon.FromPoints([new MKMapPoint(1,1)]);
            return new MKPolygonRenderer();
        }

        protected override void RemoveFromMapInternal()
        {
            Element.re
        }
    }
}
