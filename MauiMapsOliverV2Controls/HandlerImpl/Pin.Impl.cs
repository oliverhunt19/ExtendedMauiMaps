using Microsoft.Maui.Maps;

namespace Microsoft.Maui.Controls.Maps
{
    public partial class Pin : IMapPin
    {
        public double AnchorU { get; set; } = 0.5;

        public double AnchorV { get; set; } = 1;

        public double InfoWindowAnchorU { get; set; } = 0.5;

        public double InfoWindowAnchorV { get; set; } = 0;
    }


}
