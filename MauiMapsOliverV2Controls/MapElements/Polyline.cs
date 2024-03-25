using ExtendedMauiMaps.Core;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ExtendedMauiMapsControl
{
    /// <summary>
    /// Represents a polyline drawn on the map control.
    /// </summary>
    public class Polyline : StrokeMapElement, IPolylineMapElement
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
            get => (IReadOnlyList<Location>) GetValue(GeopathProperty);
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
