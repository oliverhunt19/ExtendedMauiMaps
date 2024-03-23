namespace ExtendedMauiMaps.IMauiMapElements
{
    public interface IMauiStokeMapElement : IMauiMapElement
    {
        bool Clickable { get; set; }

        Color StrokeColor { get; set; }

        double StrokeWidth { get; set; }
    }
}
