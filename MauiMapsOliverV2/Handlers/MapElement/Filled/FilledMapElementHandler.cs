using MauiMapsOliverV2.Handlers.MapElement;

namespace Microsoft.Maui.Maps.Handlers
{
    public abstract partial class FilledMapElementHandler<TVirtualView, TPlatformView> : StrokeMapElementHandler<TVirtualView, TPlatformView>, IFilledMapElementHandler
        where TPlatformView : class
        where TVirtualView : class, IFilledMapElement
    {

        public FilledMapElementHandler()// : base(Mapper)
        {

        }

        public FilledMapElementHandler(IPropertyMapper? mapper = null)
        //: base(mapper ?? Mapper)
        {
        }

        protected override TPlatformView CreatePlatformElement()
        {
            TPlatformView platformView = base.CreatePlatformElement();
            return SetFill(platformView, VirtualView.Fill as SolidPaint);
        }

        protected abstract TPlatformView SetFill(TPlatformView platformView, SolidPaint? fill);

        public static void MapFill(IFilledMapElementHandler handler, IFilledMapElement mapElement)
        {
            if(mapElement.Fill is not SolidPaint solidPaintFill)
                return;

            if(handler is FilledMapElementHandler<TVirtualView, TPlatformView> mapElementHandler)
            {
                if(handler.PlatformView is TPlatformView platformView)
                {
                    mapElementHandler.SetFill(platformView, solidPaintFill);
                }
            }
        }
    }
}
