namespace ExtendedMauiMaps.Core
{
    /// <summary>
    /// Represents a Pin that displays a map.
    /// </summary>
    public interface IMapPin : IMapElement
    {
        /// <summary>
        /// The physical address that is associated with this pin.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// The label that is shown for this pin.
        /// </summary>
        string Label { get; }

        /// <summary>
        /// The geographical location of this pin.
        /// </summary>
        Location Location { get; }

        /// <summary>
        /// Rotation in Degrees Clockwise
        /// </summary>
        double PinRotation { get; }

        ImageSource ImageSource { get; }

        bool Flatten { get; }

        double AnchorU { get; }
        double AnchorV { get; }

        double InfoWindowAnchorU { get; }

        double InfoWindowAnchorV { get; }




        bool SendInfoWindowClick();
    }
}
