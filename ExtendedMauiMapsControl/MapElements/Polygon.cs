using ExtendedMauiMaps.Core;
using System.Collections.ObjectModel;

namespace ExtendedMauiMapsControl
{
    /// <summary>
    /// Represents a polygon drawn on the map control.
    /// </summary>
    public class Polygon : FilledMapElement, IPolygonMapElement
    {
        public static readonly BindableProperty GeopathProperty = BindableProperty.Create(nameof(Geopath), typeof(IReadOnlyList<Location>), typeof(Polyline), new ObservableCollection<Location>());


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
