using Microsoft.Maui.Maps;

namespace MauiMapsOliverV2.Handlers.MapElement
{
    public abstract partial class StrokeMapElementHandler<TVirtualView, TPlatformView>
        where TPlatformView : class
        where TVirtualView : class, IMapStrokeElement
    {
    }
}
