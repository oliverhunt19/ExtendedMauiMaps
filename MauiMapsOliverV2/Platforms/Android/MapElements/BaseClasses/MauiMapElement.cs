﻿using Android.Gms.Maps;

namespace MauiMapsOliverV2.IMauiMapElements
{


    public abstract partial class MauiMapElement<T> where T : class
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
