using MauiMapsOliverV2Controls;
using System.ComponentModel;
using System.Windows.Input;

namespace Microsoft.Maui.Controls.Maps
{
    /// <summary>
    /// Represents a pin on the <see cref="Map"/> control.
    /// </summary>
    public partial class Pin : MapElement
	{
		/// <summary>Bindable property for <see cref="Type"/>.</summary>
		public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(PinType), typeof(Pin), default(PinType));

		/// <summary>Bindable property for <see cref="Location"/>.</summary>
		public static readonly BindableProperty LocationProperty = BindableProperty.Create(nameof(Location), typeof(Location), typeof(Pin), default(Location));

		/// <summary>Bindable property for <see cref="Address"/>.</summary>
		public static readonly BindableProperty AddressProperty = BindableProperty.Create(nameof(Address), typeof(string), typeof(Pin), default(string));

		/// <summary>Bindable property for <see cref="Label"/>.</summary>
		public static readonly BindableProperty LabelProperty = BindableProperty.Create(nameof(Label), typeof(string), typeof(Pin), default(string));


		public static readonly BindableProperty PinRotationProperty = BindableProperty.Create(nameof(PinRotation), typeof(double), typeof(Pin));
		
		
		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(ImageSource), typeof(Pin));
		public static readonly BindableProperty FlattenProperty = BindableProperty.Create(nameof(Flatten), typeof(bool), typeof(Pin));

		public static readonly BindableProperty InfoWindowClickedCommandProperty = BindableProperty.Create(nameof(InfoWindowClickedCommand), typeof(ICommand), typeof(Pin));


        /// <inheritdoc />
        public string Address
		{
			get { return (string)GetValue(AddressProperty); }
			set { SetValue(AddressProperty, value); }
		}

		/// <inheritdoc />
		public string Label
		{
			get { return (string)GetValue(LabelProperty); }
			set { SetValue(LabelProperty, value); }
		}

		/// <inheritdoc />
		public Location Location
		{
			get { return (Location)GetValue(LocationProperty); }
			set { SetValue(LocationProperty, value); }
		}

		/// <summary>
		/// Gets or sets the kind of pin. The default value is <see cref="PinType.Generic"/>.
		/// This is a bindable property.
		/// </summary>
		/// <remarks>Depending on the platform, and versions of the platform, this might change the visual representation. This varies between the different platforms.</remarks>
		public PinType Type
		{
			get { return (PinType)GetValue(TypeProperty); }
			set { SetValue(TypeProperty, value); }
		}

		public double PinRotation
		{
			get => (double)GetValue(PinRotationProperty);
			set { SetValue(PinRotationProperty, value); }
		}

        public ImageSource ImageSource
		{
			get => (ImageSource)GetValue(ImageSourceProperty);
			set => SetValue(ImageSourceProperty, value);
		}

        public bool Flatten 
		{
			get => (bool) GetValue(FlattenProperty);
			set => SetValue(FlattenProperty, value);
		}


		
		
		public ICommand? InfoWindowClickedCommand
		{
			get => (ICommand?)GetValue(InfoWindowClickedCommandProperty);
			set => SetValue(InfoWindowClickedCommandProperty,value);
		}




        

		/// <summary>
		/// Raised when the info window for this marker is clicked.
		/// </summary>
		public event EventHandler<MapElementClickedEventArgs>? InfoWindowClicked;

		/// <inheritdoc cref="object.Equals(object)"/>
		public override bool Equals(object? obj)
		{
			if (obj is null)
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((Pin)obj);
		}

		/// <inheritdoc cref="object.GetHashCode"/>
		public override int GetHashCode()
		{
			unchecked
			{
#if NETSTANDARD2_0
				int hashCode = Label?.GetHashCode() ?? 0;
				hashCode = (hashCode * 397) ^ Location.GetHashCode();
				hashCode = (hashCode * 397) ^ (int)Type;
				hashCode = (hashCode * 397) ^ (Address?.GetHashCode() ?? 0);
#else
				int hashCode = Label?.GetHashCode(StringComparison.Ordinal) ?? 0;
				hashCode = (hashCode * 397) ^ Location.GetHashCode();
				hashCode = (hashCode * 397) ^ (int)Type;
				hashCode = (hashCode * 397) ^ (Address?.GetHashCode(StringComparison.Ordinal) ?? 0);
#endif
				return hashCode;
			}
		}

		/// <summary>
		/// Equality operator for equals.
		/// </summary>
		/// <param name="left">Left to compare.</param>
		/// <param name="right">Right to compare.</param>
		/// <returns><see langword="true"/> if objects are equal, otherwise <see langword="false"/>.</returns>
		public static bool operator ==(Pin? left, Pin? right)
		{
			return Equals(left, right);
		}

		/// <summary>
		/// Inequality operator.
		/// </summary>
		/// <param name="left">Left to compare.</param>
		/// <param name="right">Right to compare.</param>
		/// <returns><see langword="true"/> if objects are not equal, otherwise <see langword="false"/>.</returns>
		public static bool operator !=(Pin? left, Pin? right)
		{
			return !Equals(left, right);
		}

		

		/// <summary>
		/// Triggers the click/tap event for a info window of a pin.
		/// </summary>
		/// <returns><see langword="true"/> if the info window associated to this pin will hide after this event has occurred, otherwise <see langword="false"/></returns>
		/// <remarks>For internal use only. This API can be changed or removed without notice at any time.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool SendInfoWindowClick()
		{
			var args = new MapElementClickedEventArgs(BindingContext);
			InfoWindowClicked?.Invoke(this, args);
            InfoWindowClickedCommand?.Execute(args);
            return args.Handled;
		}

		bool Equals(Pin other)
		{
			return string.Equals(Label, other.Label, StringComparison.Ordinal) &&
				Equals(Location, other.Location) && Type == other.Type &&
				string.Equals(Address, other.Address, StringComparison.Ordinal);
		}
	}
}
