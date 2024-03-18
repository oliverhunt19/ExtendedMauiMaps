using Android.Gms.Maps;

namespace MauiMapsOliverV2.Platforms.Android.MapElements
{
    public interface IMauiMapElement
    {
        bool Visible { get; set; }

        float ZIndex { get; set; }

        string Id { get; }

        void RemoveFromMap();
    }

    public interface IMauiStokeMapElement : IMauiMapElement
    {
        bool Clickable { get; set; }
    }

    public abstract class MauiMapElement<T> : IMauiMapElement where T : class
    {
        public MauiMapElement()
        {
        }

        protected WeakReference<T>? WeakRef { get; private set; }
        protected T? Element => WeakRef?.TryGetTarget(out var e) == true ? e : null;

        protected bool ElementHasValue => Element != null;

        protected abstract T AddToMapsInternal(GoogleMap map);

        public T AddToMap(GoogleMap map)
        {
            T element = AddToMapsInternal(map);
            WeakRef = new WeakReference<T>(element);
            return element;
        }

        public abstract bool Visible { get; set; }

        public abstract float ZIndex { get; set; }

        public abstract string Id { get; }

        public void RemoveFromMap()
        {
            RemoveFromMapInternal();
            WeakRef = null;
        }

        protected abstract void RemoveFromMapInternal();
    }

    public abstract class MauiStrokeMapElement<T> : MauiMapElement<T>, IMauiStokeMapElement where T : class
    {
        public abstract bool Clickable { get; set; }
    }
}
