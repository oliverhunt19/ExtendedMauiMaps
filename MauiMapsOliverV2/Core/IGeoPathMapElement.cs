using System.Collections.Generic;
using Microsoft.Maui.Devices.Sensors;

namespace Microsoft.Maui.Maps
{
	public interface IGeoPathMapElement : IMapStrokeElement
	{
		IReadOnlyList<Location> Geopath { get; }
	}
}