using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace MauiMapsOliverV2Controls
{
    public partial class StrokeMapElement : MapElement, IMapStrokeElement
    {
        /// <summary>Bindable property for <see cref="StrokeColor"/>.</summary>
		public static readonly BindableProperty StrokeColorProperty = BindableProperty.Create(
            nameof(StrokeColor),
            typeof(Color),
            typeof(MapElement),
            null);

        /// <summary>Bindable property for <see cref="StrokeWidth"/>.</summary>
        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create(
            nameof(StrokeWidth),
            typeof(float),
            typeof(MapElement),
            5f);

        public static readonly BindableProperty IsClickableProperty = BindableProperty.Create(
            nameof(IsClickable),
            typeof(bool),
            typeof(MapElement),
            false);

        /// <summary>
        /// Gets or sets the stroke color. This is a bindable property.
        /// </summary>
        public Color StrokeColor
        {
            get => (Color)GetValue(StrokeColorProperty);
            set => SetValue(StrokeColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the stroke width. The default value is <c>5f</c>.
        /// This is a bindable property.
        /// </summary>
        public float StrokeWidth
        {
            get => (float)GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public bool IsClickable
        {
            get => (bool)GetValue(IsClickableProperty);
            set
            {
                SetValue(IsClickableProperty, value);
            }
        }
    }
}
