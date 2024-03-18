using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;

namespace MauiMapsOliverV2.Handlers.MapElement
{
    public abstract partial class StrokeMapElementHandler<TVirtualView, TPlatformView> : MapElementHandler<TVirtualView, TPlatformView>
        where TPlatformView : class
        where TVirtualView : class, IMapStrokeElement
    {
    }
}
