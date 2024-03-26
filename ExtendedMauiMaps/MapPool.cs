using System.Collections.Concurrent;

namespace ExtendedMauiMaps.Platforms.iOS
{
    internal class MapPool<T> where T : class
    {
        static MapPool<T>? s_instance;
        public static MapPool<T> Instance => s_instance ??= new MapPool<T>();

        internal readonly ConcurrentQueue<T> Maps = new ConcurrentQueue<T>();

        public static void Add(T mapView) => Instance.Maps.Enqueue(mapView);

        public static T? Get() => Instance.Maps.TryDequeue(out T? mapView) ? mapView : null;

    }
}
