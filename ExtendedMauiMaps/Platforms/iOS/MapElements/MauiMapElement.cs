using MapKit;

namespace MauiMapsOliverV2.IMauiMapElements
{
    public abstract partial class MauiMapElement<T> where T : class
    {
        protected MKMapView? MKMapView { get; private set; }

        

        protected abstract T AddToMapsInternal(MKMapView mapView);

        public T AddToMap(MKMapView mapView)
        {
            MKMapView = mapView;
            T element = AddToMapsInternal(mapView);
            //T element = elements.Item1;

            WeakRef = new WeakReference<T>(element);
            return element;
        }


    }

    public abstract class MauiMapElementIOS<TRenderer, TOverlay> : MauiMapElement<TRenderer> where TRenderer : MKOverlayRenderer
    {
        protected TOverlay? Overlay { get; private set; }

        protected abstract (TRenderer, TOverlay) AddToMapsInternalIOS(MKMapView mapView);

        protected sealed override TRenderer AddToMapsInternal(MKMapView mapView)
        {
            (TRenderer renderer, TOverlay overlay) = AddToMapsInternalIOS(mapView);
            Overlay = overlay;
            return renderer;
        }

        protected override void RemoveFromMapInternal()
        {
            base.RemoveFromMapInternal();
        }
    }
}
