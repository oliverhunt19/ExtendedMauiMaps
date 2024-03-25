namespace MauiMapsOliverV2.IMauiMapElements
{
    public abstract partial class MauiMapElement<T> where T : class
    {
        protected abstract T AddToMapsInternal();

        public T AddToMap()
        {
            T element = AddToMapsInternal();
            WeakRef = new WeakReference<T>(element);
            return element;
        }
    }
}
