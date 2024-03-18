
#if ANDROID
using Android.Gms.Common.Data;
using PlatformView = Java.Lang.Object;


namespace MauiMapsOliverV2.Utils
{
    //https://gist.github.com/Cheesebaron/9876783
    public class JavaHolder<T> : PlatformView
    {
        public T Value { get; }

        public JavaHolder(T value)
        {
            Value = value;
        }
    }

    public static class ObjectExtensions
    {
        public static TObject? ToNetObject<TObject>(this PlatformView value)
        {
            if(value == null)
                return default;

            if(value is not JavaHolder<TObject> holder)
            {
                return default;
            }

            return holder.Value;
        }

        public static PlatformView ToJavaObject<TObject>(this TObject value)
        {
            if(Equals(value, default(TObject)) && !typeof(TObject).IsValueType)
                return null;

            var holder = new JavaHolder<TObject>(value);

            return holder;
        }
    }
}

#endif
