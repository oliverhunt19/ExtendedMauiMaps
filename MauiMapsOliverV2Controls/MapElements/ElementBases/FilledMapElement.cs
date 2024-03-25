using ExtendedMauiMaps.Core;

namespace ExtendedMauiMapsControl
{
    public class FilledMapElement : StrokeMapElement, IFilledMapElement
    {
        /// <summary>Bindable property for <see cref="FillColor"/>.</summary>
        public static readonly BindableProperty FillColourProperty = BindableProperty.Create(
            nameof(FillColour),
            typeof(Color),
            typeof(FilledMapElement),
            Colors.Transparent);

        /// <summary>
        /// Gets or sets the fill color. This is a bindable property.
        /// </summary>
        public Color FillColour
        {
            get => (Color) GetValue(FillColourProperty);
            set => SetValue(FillColourProperty, value);
        }

        public FilledMapElement()
        {

        }


    }
}
