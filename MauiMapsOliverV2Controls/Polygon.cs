using MauiMapsOliverV2.Core;
using MauiMapsOliverV2Controls;
using System.Collections.ObjectModel;

namespace Microsoft.Maui.Controls.Maps
{
    /// <summary>
    /// Represents a polygon drawn on the map control.
    /// </summary>
    public partial class Polygon : StrokeMapElement, IPolygonMapElement
	{
		public static readonly BindableProperty GeopathProperty = BindableProperty.Create(nameof(Geopath), typeof(IReadOnlyList<Location>), typeof(Polyline), new ObservableCollection<Location>());

        /// <summary>Bindable property for <see cref="FillColour"/>.</summary>
        public static readonly BindableProperty FillColourProperty = BindableProperty.Create(
			nameof(FillColour),
			typeof(Color),
			typeof(Polygon),
			Colors.Transparent);

		/// <summary>
		/// Gets or sets the fill color. This is a bindable property.
		/// </summary>
		public Color FillColour
		{
			get => (Color)GetValue(FillColourProperty);
			set => SetValue(FillColourProperty, value);
		}

        /// <summary>
        /// Gets a list of locations on the map which forms the polyline on the map.
        /// </summary>
        public IReadOnlyList<Location> Geopath
        {
            get => (IReadOnlyList<Location>)GetValue(GeopathProperty);
            set
            {
                SetValue(GeopathProperty, value);
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class.
        /// </summary>
        public Polygon()
		{
			var observable = new ObservableCollection<Location>();
			observable.CollectionChanged += (sender, args) => OnPropertyChanged(nameof(Geopath));
			Geopath = observable;
		}
	}
}
