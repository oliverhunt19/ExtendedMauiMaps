using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Maps.Handlers
{
    public enum JointType
	{
		Default = 0,
		Bevel = 1,
		Round = 2,
	}

	public abstract partial class MapElementHandler<TVirtualView, TPlatformView> : ElementHandler<TVirtualView, TPlatformView>
		where TPlatformView : class
		where TVirtualView : class, IMapElement
	{
    }
}
