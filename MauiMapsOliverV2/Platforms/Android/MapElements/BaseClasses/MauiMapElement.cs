using Android.Gms.Maps;
using ExtendedMauiMaps.IMauiMapElements;

namespace MauiMapsOliverV2.IMauiMapElements
{


    public abstract partial class MauiMapElement<T> : IMauiMapElement where T : class
    {
        public MauiMapElement()
        {
        }

        

        protected abstract T AddToMapsInternal(GoogleMap map);

        public T AddToMap(GoogleMap map)
        {
            T element = AddToMapsInternal(map);
            WeakRef = new WeakReference<T>(element);
            return element;
        }

        
    }

    

    
}
