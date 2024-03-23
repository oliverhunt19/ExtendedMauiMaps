using MauiMapsOliverV2.IMauiMapElements;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;

namespace MauiMapsOliverV2.Handlers.MapElement
{
    public abstract partial class StrokeMapElementHandler<TVirtualView, TPlatformView> : MapElementHandler<TVirtualView, TPlatformView>, IStrokeMapElementHandler
        where TPlatformView : class, IMauiStokeMapElement
        where TVirtualView : class , IMapStrokeElement
    {

        public static IPropertyMapper<IMapStrokeElement, StrokeMapElementHandler<TVirtualView, TPlatformView>> StrokeMapElementMapper = new PropertyMapper<IMapStrokeElement, StrokeMapElementHandler<TVirtualView, TPlatformView>>(Mapper)
        {
            [nameof(IMapStrokeElement.Stroke)] = UpdateMapStroke,
            [nameof(IMapStrokeElement.IsClickable)] = UpdateMapClickable,
            [nameof(IMapStrokeElement.StrokeThickness)] = UpdateMapStrokeWidth
        };

        

        public StrokeMapElementHandler() : base(StrokeMapElementMapper)
        {

        }

        public StrokeMapElementHandler(IPropertyMapper? mapper = null)
        : base(mapper ?? StrokeMapElementMapper)
        {
        }

        private static void UpdateMapStroke(StrokeMapElementHandler<TVirtualView, TPlatformView> handler, IMapStrokeElement mapElement)
        {
            handler.PlatformView.StrokeColor = mapElement.Stroke;   
        }

        private static void UpdateMapStrokeWidth(StrokeMapElementHandler<TVirtualView, TPlatformView> handler, IMapStrokeElement element)
        {
            handler.PlatformView.StrokeWidth = element.StrokeThickness;
        }

        private static void UpdateMapClickable(StrokeMapElementHandler<TVirtualView, TPlatformView> handler, IMapStrokeElement element)
        {
            handler.PlatformView.Clickable = element.IsClickable;
        }

    }
}
