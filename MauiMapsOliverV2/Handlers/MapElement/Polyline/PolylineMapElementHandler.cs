using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement.Polyline;





#if __IOS__ || MACCATALYST
using PlatformView = MapKit.IMKAnnotation;
#elif ANDROID
using Android.Gms.Maps;
using PlatformView = ExtendedMauiMaps.Platforms.Android.MapElements.MauiMapPolyline;
#elif WINDOWS
using PlatformView = System.Object;
#elif TIZEN
using PlatformView = System.Object;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0 && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolylineMapElementHandler : IPolylineMapElementHandler
    {
        public static IPropertyMapper<IPolylineMapElement, PolylineMapElementHandler> PolylineMapper = new PropertyMapper<IPolylineMapElement, PolylineMapElementHandler>(StrokeMapElementMapper)
        {
            [nameof(IPolylineMapElement.Geopath)] = UpdateGeopath
        };


        public PolylineMapElementHandler() : base(PolylineMapper)
        {

        }

        public PolylineMapElementHandler(IPropertyMapper? mapper = null)
        : base(mapper ?? PolylineMapper)
        {
        }

    }
}
