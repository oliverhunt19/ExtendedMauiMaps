using MauiMapsOliverV2.Handlers.MapElement;
using MauiMapsOliverV2.IMauiMapElements;

namespace Microsoft.Maui.Maps.Handlers
{
    public abstract partial class FilledMapElementHandler<TVirtualView, TPlatformView> : StrokeMapElementHandler<TVirtualView, TPlatformView>, IFilledMapElementHandler
        where TPlatformView : class, IMauiFilledMapElement
        where TVirtualView : class, IFilledMapElement
    {

        public static IPropertyMapper<IFilledMapElement, FilledMapElementHandler<TVirtualView, TPlatformView>> FilledMapMapper = new PropertyMapper<IFilledMapElement, FilledMapElementHandler<TVirtualView, TPlatformView>>(StrokeMapElementMapper)
        {
            [nameof(IFilledMapElement.Fill)] = UpdateMapFill
        };

        private static void UpdateMapFill(FilledMapElementHandler<TVirtualView, TPlatformView> handler, IFilledMapElement element)
        {
            if(element.Fill is not SolidPaint solidPaint)
            {
                return;
            }
            handler.PlatformView.FillColour = solidPaint.Color;
        }

        public FilledMapElementHandler() : base(FilledMapMapper)
        {

        }

        public FilledMapElementHandler(IPropertyMapper? mapper = null)
        : base(mapper ?? Mapper)
        {
        }

    }
}
