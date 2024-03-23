namespace ExtendedMauiMaps.Core
{
    /// <summary>
    /// Represents a visual element on the map control that has a fill color.
    /// </summary>
    public interface IFilledMapElement : IMapStrokeElement
    {
        /// <summary>
        /// Gets the fill color.
        /// </summary>
        Color FillColour { get; }
    }
}
