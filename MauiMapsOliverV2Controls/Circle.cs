using MauiMapsOliverV2Controls;
using Microsoft.Maui.Maps;

namespace Microsoft.Maui.Controls.Maps
{
    /// <summary>
    /// Represents a circle drawn on the map control.
    /// </summary>
    public partial class Circle : StrokeMapElement , ICircleMapElement
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

		/// <summary>Bindable property for <see cref="FillColor"/>.</summary>
		public static readonly BindableProperty FillColourProperty = BindableProperty.Create(
			nameof(FillColour),
			typeof(Color),
			typeof(Circle),
			Colors.Transparent);

		/// <summary>
		/// Gets or sets the center location. This is a bindable property.
		/// </summary>
		public Location Center
		{
			get => (Location)GetValue(CenterProperty);
			set => SetValue(CenterProperty, value);
		}

		/// <summary>
		/// Gets or sets the radius. This is a bindable property.
		/// </summary>
		public Distance Radius
		{
			get => (Distance)GetValue(RadiusProperty);
			set => SetValue(RadiusProperty, value);
		}

		/// <summary>
		/// Gets or sets the fill color. This is a bindable property.
		/// </summary>
		public Color FillColour
		{
			get => (Color)GetValue(FillColourProperty);
			set => SetValue(FillColourProperty, value);
		}
    }
}
