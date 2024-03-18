using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MauiMapsOliverV2Controls;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Handlers;

namespace Microsoft.Maui.Controls.Maps
{
	/// <summary>
	/// Represents a polyline drawn on the map control.
	/// </summary>
	public partial class Polyline : StrokeMapElement
	{
		public static readonly BindableProperty GeopathProperty = BindableProperty.Create(nameof(Geopath), typeof(IList<Location>), typeof(Polyline), new ObservableCollection<Location>());
		 

        private void OnGeopathCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            Handler?.UpdateValue("Geopath");
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
		/// Initializes a new instance of the <see cref="Polyline"/> class.
		/// </summary>
		public Polyline()
		{
			var observable = new ObservableCollection<Location>();
			observable.CollectionChanged += (sender, args) => OnPropertyChanged(nameof(Geopath));
			Geopath = observable;
		}
	}
}
