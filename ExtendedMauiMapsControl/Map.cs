using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.Map;
using ExtendedMauiMaps.Primitives;
using Microsoft.Maui.Controls.Internals;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using IMap = ExtendedMauiMaps.Core.IMap;

namespace ExtendedMauiMapsControl
{
    /// <summary>
    /// The Map control is a cross-platform view for displaying and annotating maps.
    /// </summary>
    public partial class Map : View
	{
        #region Bindable Properties
        /// <summary>Bindable property for <see cref="MapType"/>.</summary>
        public static readonly BindableProperty MapTypeProperty = BindableProperty.Create(nameof(MapType), typeof(MapType), typeof(Map), default(MapType));

		/// <summary>Bindable property for <see cref="IsShowingUser"/>.</summary>
		public static readonly BindableProperty IsShowingUserProperty = BindableProperty.Create(nameof(IsShowingUser), typeof(bool), typeof(Map), default(bool));

		/// <summary>Bindable property for <see cref="IsTrafficEnabled"/>.</summary>
		public static readonly BindableProperty IsTrafficEnabledProperty = BindableProperty.Create(nameof(IsTrafficEnabled), typeof(bool), typeof(Map), default(bool));

		/// <summary>Bindable property for <see cref="IsScrollEnabled"/>.</summary>
		public static readonly BindableProperty IsScrollEnabledProperty = BindableProperty.Create(nameof(IsScrollEnabled), typeof(bool), typeof(Map), true);

		/// <summary>Bindable property for <see cref="IsZoomEnabled"/>.</summary>
		public static readonly BindableProperty IsZoomEnabledProperty = BindableProperty.Create(nameof(IsZoomEnabled), typeof(bool), typeof(Map), true);

		///// <summary>Bindable property for <see cref="ItemsSource"/>.</summary>
		//public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(Map), default(IEnumerable),
		//	propertyChanged: (b, o, n) => ((Map)b).OnItemsSourcePropertyChanged((IEnumerable)o, (IEnumerable)n));

		/// <summary>Bindable property for <see cref="ItemTemplate"/>.</summary>
		//public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(Map), default(DataTemplate));
			//propertyChanged: (b, o, n) => ((Map)b).OnItemTemplatePropertyChanged((DataTemplate)o, (DataTemplate)n));

		/// <summary>Bindable property for <see cref="ItemTemplateSelector"/>.</summary>
		public static readonly BindableProperty ItemTemplateSelectorProperty = BindableProperty.Create(nameof(ItemTemplateSelector), typeof(DataTemplateSelector), typeof(Map), default(DataTemplateSelector),
			propertyChanged: (b, o, n) => ((Map)b).OnItemTemplateSelectorPropertyChanged());

        

        public static readonly BindableProperty MapElementsSourceProperty = BindableProperty.Create(nameof(MapElementsSource), typeof(IEnumerable), typeof(Map), default(IEnumerable), 
			propertyChanged: (b, o, n) => ((Map)b).OnMapElementsPropertyChanged((IEnumerable)o, (IEnumerable)n));

		public static readonly BindableProperty MapElementsItemTemplateProperty = BindableProperty.Create(nameof(MapElementDataTemplate), typeof(DataTemplate), typeof(Map), default(DataTemplateSelector)
            );

		public static readonly BindableProperty MapSpanProperty = BindableProperty.Create(nameof(MapSpan), typeof(MapSpan), typeof(Map), propertyChanged: (b,o,n)=>((Map)b).MoveToRegion((MapSpan)n));

        


        #endregion

        #region Fields
  //      readonly ObservableCollection<Pin> _pins = new();
		private readonly ObservableCollection<MapElement> _mapElements = new();
		private MapSpan? _visibleRegion;
		private MapSpan? _lastMoveToRegion;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class with a region.
        /// </summary>
        /// <param name="region">The region that should be initially shown by the map.</param>
        public Map(MapSpan region)
		{
			MoveToRegion(region);
#pragma warning disable CS0618 // Type or member is obsolete
			VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand;
#pragma warning restore CS0618 // Type or member is obsolete

			_mapElements.CollectionChanged += MapElementsCollectionChanged;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Map"/> class with a region.
		/// </summary>
		// <remarks>The selected region will default to Maui, Hawaii.</remarks>
		public Map() : this(new MapSpan(new Location(20.793062527, -156.336394697), 0.5, 0.5))
		{
			MoveToDeviceLocation();
        }

		private async void MoveToDeviceLocation()
		{
			try
			{
                PermissionStatus permissionStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (permissionStatus is PermissionStatus.Granted)
                {
                    Location? location = await Geolocation.Default.GetLastKnownLocationAsync();
                    if (location is not null)
                    {
                        MapSpan region = new MapSpan(location, 0.5, 0.5);
                        MoveToRegion(region);
                    }
                }
            }
			catch
			{

			}
			

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value that indicates if scrolling by user input is enabled. Default value is <see langword="true"/>.
        /// This is a bindable property.
        /// </summary>
        public bool IsScrollEnabled
		{
			get { return (bool)GetValue(IsScrollEnabledProperty); }
			set { SetValue(IsScrollEnabledProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value that indicates if zooming by user input is enabled. Default value is <see langword="true"/>.
		/// This is a bindable property.
		/// </summary>
		public bool IsZoomEnabled
		{
			get { return (bool)GetValue(IsZoomEnabledProperty); }
			set { SetValue(IsZoomEnabledProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value that indicates if the map shows an indicator of the current position of this device. Default value is <see langword="false"/>
		/// This is a bindable property.
		/// </summary>
		/// <remarks>Depending on the platform it is likely that runtime permission(s) need to be requested to determine the current location of the device.</remarks>
		public bool IsShowingUser
		{
			get { return (bool)GetValue(IsShowingUserProperty); }
			set { SetValue(IsShowingUserProperty, value); }
		}

		/// <summary>
		/// Gets or sets a value that indicates if the map shows current traffic information. Default value is <see langword="false"/>.
		/// This is a bindable property.
		/// </summary>
		public bool IsTrafficEnabled
		{
			get => (bool)GetValue(IsTrafficEnabledProperty);
			set => SetValue(IsTrafficEnabledProperty, value);
		}

		/// <summary>
		/// Gets or sets the style of the map. Default value is <see cref="MapType.Street"/>. 
		/// This is a bindable property.
		/// </summary>
		public MapType MapType
		{
			get { return (MapType)GetValue(MapTypeProperty); }
			set { SetValue(MapTypeProperty, value); }
		}

		//      /// <summary>
		//      /// Gets or sets the object that represents the collection of pins that should be shown on the map.
		//      /// This is a bindable property.
		//      /// </summary>
		//      public IEnumerable ItemsSource
		//{
		//	get { return (IEnumerable)GetValue(ItemsSourceProperty); }
		//	set { SetValue(ItemsSourceProperty, value); }
		//}

		///// <summary>
		///// Gets or sets the template that is to be applied to each object in <see cref="ItemsSource"/>.
		///// This is a bindable property.
		///// </summary>
		//public DataTemplate ItemTemplate
		//{
		//	get { return (DataTemplate)GetValue(ItemTemplateProperty); }
		//	set { SetValue(ItemTemplateProperty, value); }
		//}

		/// <summary>
		/// Gets or sets the object that selects the template that is to be applied to each object in <see cref="ItemsSource"/>.
		/// This is a bindable property.
		/// </summary>
		public DataTemplateSelector ItemTemplateSelector
		{
			get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
			set { SetValue(ItemTemplateSelectorProperty, value); }
		}

		public IEnumerable MapElementsSource
		{
			get
			{
				return (IEnumerable )GetValue(MapElementsSourceProperty);
			}
			set
			{
				SetValue(MapElementsSourceProperty, value);
			}
		}

		public DataTemplate MapElementDataTemplate
		{
			get { return (DataTemplate)GetValue(MapElementsItemTemplateProperty); }
			set { SetValue(MapElementsItemTemplateProperty, value); }
		}

		/// <summary>
		/// Occurs when the user clicks/taps on the map control.
		/// </summary>
		public event EventHandler<MapClickedEventArgs>? MapClicked;

		/// <summary>
		/// Gets the currently visible region of the map.
		/// </summary>
		public MapSpan? VisibleRegion
		{
			get { return _visibleRegion; }
		}


		public MapSpan MapSpan
		{
			get=> (MapSpan)GetValue(MapSpanProperty);
			set => SetValue(MapSpanProperty, value);
		}

        IList<IMapElement> IMap.Elements => _mapElements.OfType<IMapElement>().ToList();

        IList<IMapPin> IMap.Pins => _mapElements.OfType<IMapPin>().ToList();

        #endregion


        /// <summary>
        /// Adjusts the viewport of the map control to view the specified region.
        /// </summary>
        /// <param name="mapSpan">A <see cref="MapSpan"/> object containing details on what region should be shown.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="mapSpan"/> is <see langword="null"/>.</exception>
        public void MoveToRegion(MapSpan mapSpan)
		{
			if (mapSpan is null)
			{
				throw new ArgumentNullException(nameof(mapSpan));
			}

			_lastMoveToRegion = mapSpan;
			Handler?.Invoke(nameof(IMap.MoveToRegion), _lastMoveToRegion);
		}

		void SetVisibleRegion(MapSpan? visibleRegion)
		{
			if (visibleRegion is null)
			{
				throw new ArgumentNullException(nameof(visibleRegion));
			}

			if (_visibleRegion == visibleRegion)
			{
				return;
			}

			OnPropertyChanging(nameof(VisibleRegion));
			_visibleRegion = visibleRegion;
			OnPropertyChanged(nameof(VisibleRegion));
		}

        #region MapSouurceElementCHanged

        private void OnMapElementsPropertyChanged(IEnumerable o, IEnumerable n)
        {
            if(o is INotifyCollectionChanged ncc)
            {
                ncc.CollectionChanged -= OnMapElementsCollectionChanged;
            }

            if(n is INotifyCollectionChanged ncc1)
            {
                ncc1.CollectionChanged += OnMapElementsCollectionChanged;
            }

            
            CreateMapElements();
        }

        void OnMapElementsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            e.Apply(
                insert: (item, _, __) => CreateMapElement(item),
                removeAt: (item, _) => RemoveMapElement(item),
                reset: () => _mapElements.Clear());

        }

        


        private void CreateMapElements()
        {
            if(MapElementsSource is null || (MapElementDataTemplate is null && ItemTemplateSelector is null))
            {
                return;
            }

            _mapElements.Clear();
            foreach(object item in MapElementsSource)
            {
                CreateMapElement(item);
            }
        }


		// If the item template selector is null a pin is created by default
        void CreateMapElement(object newItem)
        {
            DataTemplate? itemTemplate = ItemTemplateSelector?.SelectTemplate(newItem, this);
			itemTemplate ??= MapElementDataTemplate;

            MapElement? pin = itemTemplate?.CreateContent() as MapElement;
			if(pin is null)
			{
				return;
			}
            pin.BindingContext = newItem;
            _mapElements.Add(pin);
        }

        private void RemoveMapElement(object itemToRemove)
        {
            //// Instead of just removing by item (i.e. _pins.Remove(pinToRemove))
            ////  we need to remove by index because of how Pin.Equals() works
            for(int i = 0; i < _mapElements.Count; ++i)
            {
                MapElement? pin = _mapElements[i];
                if(pin is not null)
                {
                    if(pin.BindingContext?.Equals(itemToRemove) == true)
                    {
                        _mapElements.RemoveAt(i);
                    }
                }
            }
        }

        #endregion


        void MapElementsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {

            Handler?.Invoke(nameof(IMapHandler.ElementsCollectionChanged), e);
        }

        private void OnItemTemplateSelectorPropertyChanged()
        {
            throw new NotImplementedException();
        }

    }
}