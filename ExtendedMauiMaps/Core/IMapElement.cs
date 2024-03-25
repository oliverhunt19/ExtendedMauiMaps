namespace ExtendedMauiMaps.Core
{
    /// <summary>
    /// Represents an element that can be added to the map control.
    /// </summary>
    public interface IMapElement : IElement
    {
        /// <summary>
        /// Gets or sets the platform counterpart of this map element.
        /// </summary>
        object? MapElementId { get; set; }

        bool SendElementClick();

    }

    public interface IMapStrokeElement : IMapElement
    {
        bool IsClickable { get; }

        Color Stroke { get; }

        double StrokeThickness { get; }
    }
}
