using MauiMapsOliverV2Controls;
using System.ComponentModel;
using System.Windows.Input;

namespace Microsoft.Maui.Controls.Maps
{
    /// <summary>
    /// Represents an element which is visually drawn on the <see cref="Map"/> control.
    /// </summary>
    public partial class MapElement : Element
	{

        public static readonly BindableProperty MapElementClickedCommandProperty = BindableProperty.Create(nameof(MapElementClickedCommand), typeof(ICommand), typeof(MapElement));

        public static readonly BindableProperty MapElementClickedCommandParameterProperty = BindableProperty.Create(nameof(MapElementClickedCommandParameter), typeof(object), typeof(MapElement), null);

        /// <summary>
        /// Gets or sets the platform counterpart of this map element.
        /// </summary>
        /// <remarks>This should typically not be set by the developer. Doing so might result in unpredictable behavior.</remarks>
        public object? MapElementId { get; set; }

        /// <summary>
        /// Raised when this marker is clicked.
        /// </summary>
        public event EventHandler<MapElementClickedEventArgs>? MapElementClicked;

        public ICommand? MapElementClickedCommand
        {
            get => (ICommand?)GetValue(MapElementClickedCommandProperty);
            set => SetValue(MapElementClickedCommandProperty, value);
        }

        public object? MapElementClickedCommandParameter
        {
            get => GetValue(MapElementClickedCommandParameterProperty);
            set => SetValue(MapElementClickedCommandParameterProperty, value);
        }


        /// <summary>
		/// Triggers the click/tap event for a pin.
		/// </summary>
		/// <returns><see langword="true"/> if the info window associated to this pin will hide after this event has occurred, otherwise <see langword="false"/></returns>
		/// <remarks>For internal use only. This API can be changed or removed without notice at any time.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool SendElementClick()
        {
            var args = new MapElementClickedEventArgs(BindingContext);
            MapElementClicked?.Invoke(this, args);
            if (MapElementClickedCommandParameter is not null)
            {
                MapElementClickedCommand?.Execute(MapElementClickedCommandParameter);
            }
            else
            {
                MapElementClickedCommand?.Execute(args);
            }
            
            return args.Handled;
        }
    }
}
