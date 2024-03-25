using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Core;
using MauiMapsOliverV2.Utils;
using System.ComponentModel;
using ACircle = Android.Gms.Maps.Model.Circle;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal class CircleManager : StrokeElementManager<ACircle, CircleOptions, ICircleMapElement>
    {
        public CircleManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IEnumerable<ICircleMapElement>> mapElementClicked) : base(mauiContext, map, mapElementClicked)
        {
        }

        public void Map_CircleClick(object? sender, GoogleMap.CircleClickEventArgs e)
        {
            ShapeClicked(e.Circle);
        }

        protected override void ClearElement(ACircle nativeElement)
        {
            nativeElement.Remove();
        }

        protected override ClickedPolyline GetClickedElement(ACircle element)
        {
            string? tagElement = element.Tag.ToNetObject<string>();
            return new CircleClicked(element);
        }

        protected override string GetNativeID(ACircle nativeElement)
        {
            return nativeElement.Id;
        }

        private class CircleClicked : ClickedPolyline
        {
            public CircleClicked(ACircle previous) : base(previous)
            {
            }

            protected override int GetColour(ACircle element)
            {
                return element.StrokeColor;
            }

            protected override void SetColour(ACircle element, int Colour)
            {
                element.StrokeColor = Colour;
            }
        }
    }

    public static class PropertyUpdater
    {
        public static void UpdateElement<T>(this PropertyChangedEventArgs e, Action<T> val, T setVal, string PropertyName)
        {
            if(e.PropertyName == PropertyName)
            {
                val.Invoke(setVal);
            }
        }
    }
}
