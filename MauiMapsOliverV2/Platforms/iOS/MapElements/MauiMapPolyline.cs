using MapKit;
using MauiMapsOliverV2.IMauiMapElements;

namespace MauiMapsOliverV2.Platforms.iOS.MapElements
{
    public class MauiMapPolyline : MauiStrokeMapElement<MKPolyline>
    {
        public override bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override float ZIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string Id => throw new NotImplementedException();

        public override bool Clickable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Color StrokeColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double StrokeWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override MKPolyline AddToMapsInternal()
        {
            return new MKPolyline();
        }

        protected override void RemoveFromMapInternal()
        {
            throw new NotImplementedException();
        }
    }
}
