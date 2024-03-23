using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement;
using ExtendedMauiMaps.IMauiMapElements;

namespace ExtendedMauiMaps.Handlers.MapElement.Filled
{
    public abstract partial class FilledMapElementHandler<TVirtualView, TPlatformView> : StrokeMapElementHandler<TVirtualView, TPlatformView>, IFilledMapElementHandler
        where TPlatformView : class, IMauiFilledMapElement
        where TVirtualView : class, IFilledMapElement
    {

        public static IPropertyMapper<IFilledMapElement, FilledMapElementHandler<TVirtualView, TPlatformView>> FilledMapMapper = new PropertyMapper<IFilledMapElement, FilledMapElementHandler<TVirtualView, TPlatformView>>(StrokeMapElementMapper)
        {
            [nameof(IFilledMapElement.FillColour)] = UpdateMapFill
        };

        private static void UpdateMapFill(FilledMapElementHandler<TVirtualView, TPlatformView> handler, IFilledMapElement element)
        {
            handler.PlatformView.FillColour = element.FillColour;
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
