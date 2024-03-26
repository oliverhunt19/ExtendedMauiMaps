using ExtendedMauiMaps.Core;
using System.ComponentModel;

namespace ExtendedMauiMaps.Handlers.MapElement
{
    public record MapElementHandlerUpdate(int Index, IMapElement MapElement);

    public record MapElementHandlerUpdateProperty(PropertyChangedEventArgs e, IMapElement MapElement);

}
