namespace MauiMapsOliverV2Controls
{
    public class MapElementClickedEventArgs : EventArgs
    {
        public bool Handled {  get; set; }

        public object Context { get; }

        public MapElementClickedEventArgs(object ItemContext)
        {
            Handled = false;
            Context = ItemContext;
        }
    }
}
