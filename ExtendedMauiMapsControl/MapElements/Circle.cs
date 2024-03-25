using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Primitives;

namespace ExtendedMauiMapsControl
{
    /// <summary>
    /// Represents a circle drawn on the map control.
    /// </summary>
    public class Circle : FilledMapElement, ICircleMapElement
    {
        /// <summary>Bindable property for <see cref="Center"/>.</summary>
        public static readonly BindableProperty CenterProperty = BindableProperty.Create(
            nameof(Center),
            typeof(Location),
            typeof(Circle),
            default(Location));

        /// <summary>Bindable property for <see cref="Radius"/>.</summary>
        public static readonly BindableProperty RadiusProperty = BindableProperty.Create(
            nameof(Radius),
            typeof(Distance),
            typeof(Circle),
            default(Distance));

        

        /// <summary>
        /// Gets or sets the center location. This is a bindable property.
        /// </summary>
        public Location Center
        {
            get => (Location) GetValue(CenterProperty);
            set => SetValue(CenterProperty, value);
        }

        /// <summary>
        /// Gets or sets the radius. This is a bindable property.
        /// </summary>
        public Distance Radius
        {
            get => (Distance) GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }

        
    }
}
