using System.Collections.Generic;
using Microsoft.Maui.Devices.Sensors;

namespace ExtendedMauiMaps.Core
{
    public interface IGeoPathMapElement : IMapStrokeElement
    {
        IReadOnlyList<Location> Geopath { get; }
    }
}