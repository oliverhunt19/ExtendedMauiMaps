using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;

namespace MauiMapsOliverV2.Handlers.MapElement
{
    public abstract partial class StrokeMapElementHandler<TVirtualView, TPlatformView> : MapElementHandler<TVirtualView, TPlatformView>, IFilledMapElementHandler
        where TPlatformView : class
        where TVirtualView : class , IMapStrokeElement
    {

        public static void MapStroke(IMapElementHandler handler, IMapStrokeElement mapElement)
        {
            if(mapElement.Stroke is not SolidPaint solidPaint)
                return;
            if(handler.PlatformView is TPlatformView platformView)
            {
                if(handler is StrokeMapElementHandler<TVirtualView, TPlatformView> mapElementHandler)
                {
                    mapElementHandler.SetStroke(platformView, solidPaint);
                }
            }
        }

        public static void MapStrokeThickness(IMapElementHandler handler, IMapStrokeElement mapElement)
        {
            if(handler.PlatformView is TPlatformView platformView)
            {
                if(handler is StrokeMapElementHandler<TVirtualView, TPlatformView> mapElementHandler)
                {
                    mapElementHandler.SetStrokeThickness(platformView, (float?) mapElement.StrokeThickness);
                }
            }
        }

        protected override TPlatformView CreatePlatformElement()
        {
            TPlatformView element = base.CreatePlatformElement();
            SetStrokeThickness(element, (float?) VirtualView.StrokeThickness);
            SetClickable(element, VirtualView.IsClickable);
            return SetStroke(element, VirtualView.Stroke as SolidPaint);
        }

        protected abstract TPlatformView SetStroke(TPlatformView platformView, SolidPaint? fill);

        protected abstract TPlatformView SetStrokeThickness(TPlatformView circleOptions, float? width);

        protected abstract TPlatformView SetClickable(TPlatformView platformView, bool clickable);
    }
}
