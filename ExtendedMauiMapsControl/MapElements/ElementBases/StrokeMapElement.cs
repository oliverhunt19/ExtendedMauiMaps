using ExtendedMauiMaps.Core;

namespace ExtendedMauiMapsControl
{
    public class StrokeMapElement : MapElement, IMapStrokeElement
    {
        /// <summary>Bindable property for <see cref="Stroke"/>.</summary>
		public static readonly BindableProperty StrokeProperty = BindableProperty.Create(
            nameof(Stroke),
            typeof(Color),
            typeof(MapElement),
            Colors.Black);

        /// <summary>Bindable property for <see cref="StrokeThickness"/>.</summary>
        public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(
            nameof(StrokeThickness),
            typeof(double),
            typeof(MapElement),
            5.0);

        public static readonly BindableProperty IsClickableProperty = BindableProperty.Create(
            nameof(IsClickable),
            typeof(bool),
            typeof(MapElement),
            false);

        /// <summary>
        /// Gets or sets the stroke color. This is a bindable property.
        /// </summary>
        public Color Stroke
        {
            get => (Color) GetValue(StrokeProperty);
            set => SetValue(StrokeProperty, value);
        }

        /// <summary>
        /// Gets or sets the stroke width. The default value is <c>5f</c>.
        /// This is a bindable property.
        /// </summary>
        public double StrokeThickness
        {
            get => (double) GetValue(StrokeThicknessProperty);
            set => SetValue(StrokeThicknessProperty, value);
        }

        public bool IsClickable
        {
            get => (bool) GetValue(IsClickableProperty);
            set
            {
                SetValue(IsClickableProperty, value);
            }
        }
    }
}
