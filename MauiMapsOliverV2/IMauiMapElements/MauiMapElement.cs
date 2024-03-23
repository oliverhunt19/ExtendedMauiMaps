namespace MauiMapsOliverV2.IMauiMapElements
{
    public abstract partial class MauiMapElement<T> where T : class
    {
        protected WeakReference<T>? WeakRef { get; private set; }
        protected T? Element => WeakRef?.TryGetTarget(out var e) == true ? e : null;

        protected bool ElementHasValue => Element != null;

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
}
