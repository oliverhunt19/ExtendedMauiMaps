using ExtendedMauiMaps.IMauiMapElements;
using MapKit;

namespace ExtendedMauiMaps.Platforms.iOS.MapElements
{
    public class MauiMapPolyline : MauiStrokeMapElement<MKPolylineRenderer>
    {
        public override bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override float ZIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string Id => throw new NotImplementedException();

        public override bool Clickable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Color StrokeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double StrokeWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override MKPolylineRenderer AddToMapsInternal(MKMapView mapView)
        {
            return new MKPolylineRenderer();
        }

        protected override void RemoveFromMapInternal()
        {
            throw new NotImplementedException();
        }
    }
}
