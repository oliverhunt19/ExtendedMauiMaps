using ExtendedMauiMaps.IMauiMapElements;
using MapKit;
using MauiMapsOliverV2.IMauiMapElements;

namespace ExtendedMauiMaps.Platforms.iOS.MapElements
{
    public class MauiMapCircle : MauiMapElementIOS<MKCircleRenderer,MKCircle> , IMauiFilledMapElement
    {
        public override bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override float ZIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string Id => throw new NotImplementedException();

        public  Color FillColour { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public  bool Clickable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public  Color StrokeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public  double StrokeWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override (MKCircleRenderer, MKCircle) AddToMapsInternalIOS(MKMapView mapView)
        {
            MKCircle circle = MKCircle.Circle(new CoreLocation.CLLocationCoordinate2D(),1000.0);

            mapView.AddOverlay(circle);
            MKCircleRenderer? circleRenderer = mapView.RendererForOverlay(circle) as MKCircleRenderer;
            if(circleRenderer == null)
            {
                throw new InvalidOperationException("The overlay did not get added properly");
            }
            return (circleRenderer,circle);
        }

        protected override void RemoveFromMapInternal()
        {
            if(Overlay != null)
            {
                MKMapView?.RemoveOverlay(Overlay);
            }
            
        }
    }
}
