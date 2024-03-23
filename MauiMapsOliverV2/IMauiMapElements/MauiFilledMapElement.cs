namespace MauiMapsOliverV2.IMauiMapElements
{


    public abstract class MauiFilledMapElement<T> : MauiStrokeMapElement<T>, IMauiFilledMapElement
        where T : class
    {
        public abstract Color FillColour { get; set; }
    }
}
