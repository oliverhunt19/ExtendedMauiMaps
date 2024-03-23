namespace MauiMapsOliverV2.IMauiMapElements
{



    public abstract class MauiStrokeMapElement<T> : MauiMapElement<T>, IMauiStokeMapElement where T : class
    {
        public abstract bool Clickable { get; set; }
        public abstract Color StrokeColor { get; set; }
        public abstract double StrokeWidth { get; set; }
    }
}
