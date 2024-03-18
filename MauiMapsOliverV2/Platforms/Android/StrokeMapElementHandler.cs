using MauiMapsOliverV2.Platforms.Android.MapElements;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;

namespace MauiMapsOliverV2.Handlers.MapElement
{
    public abstract partial class StrokeMapElementHandler<TVirtualView, TPlatformView> : MapElementHandler<TVirtualView, TPlatformView>
        where TPlatformView : class, IMauiStokeMapElement
        where TVirtualView : class, IMapStrokeElement
    {
    }
}
