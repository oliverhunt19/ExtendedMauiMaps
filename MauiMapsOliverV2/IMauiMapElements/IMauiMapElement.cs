namespace ExtendedMauiMaps.IMauiMapElements
{
    public interface IMauiMapElement
    {
        bool Visible { get; set; }

        float ZIndex { get; set; }

        string Id { get; }

        void RemoveFromMap();
    }
}
