using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MauiMapsOliverV2Controls;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Controls.Maps
{
	/// <summary>
	/// Represents a polygon drawn on the map control.
	/// </summary>
	public partial class Polygon : StrokeMapElement
	{
		public static readonly BindableProperty GeopathProperty = BindableProperty.Create(nameof(Geopath), typeof(IReadOnlyList<Location>), typeof(Polyline), new ObservableCollection<Location>());

        /// <summary>Bindable property for <see cref="FillColor"/>.</summary>
        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(
			nameof(FillColor),
			typeof(Color),
			typeof(Polygon),
			default(Color));

		/// <summary>
		/// Gets or sets the fill color. This is a bindable property.
		/// </summary>
		public Color FillColor
		{
			get => (Color)GetValue(FillColorProperty);
			set => SetValue(FillColorProperty, value);
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
