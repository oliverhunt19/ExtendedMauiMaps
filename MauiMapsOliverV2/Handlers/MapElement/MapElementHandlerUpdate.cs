using System.ComponentModel;

namespace Microsoft.Maui.Maps.Handlers
{
    public record MapElementHandlerUpdate(int Index, IMapElement MapElement);

	public record MapElementHandlerUpdateProperty(PropertyChangedEventArgs e, IMapElement MapElement);

}
