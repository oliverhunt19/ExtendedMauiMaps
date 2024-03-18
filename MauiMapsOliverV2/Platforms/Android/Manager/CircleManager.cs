using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Maps;
using Microsoft.Maui.Maps.Platform;
using System.ComponentModel;
using ACircle = Android.Gms.Maps.Model.Circle;

namespace MauiMapsOliverV2.Platforms.Android.Manager
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

        protected override ACircle AddElement(CircleOptions options)
        {
            return GetGoogleMap.Invoke().AddCircle(options);
        }

        protected override void ClearElement(ACircle nativeElement)
        {
            nativeElement.Remove();
        }

        protected override ClickedPolyline GetClickedPolyline(ACircle element)
        {
            return new CircleClicked(element);
        }

        protected override string GetNativeID(ACircle nativeElement)
        {
            return nativeElement.Id;
        }

        protected override void UpdateAndroidElement(ICircleMapElement mapElement, ACircle androideleent, PropertyChangedEventArgs e)
        {
            e.UpdateElement((x) => androideleent.Center = x, mapElement.Center.ToALatLng(), nameof(ICircleMapElement.Center));
            e.UpdateElement((x) => androideleent.Radius = x, mapElement.Radius.Meters, nameof(ICircleMapElement.Radius));
            e.UpdateElement((x) => androideleent.Clickable = x, mapElement.IsClickable, nameof(ICircleMapElement.IsClickable));
            e.UpdateElement((x) => androideleent.FillColor = x, (mapElement.Fill as SolidPaint).Color.AsColor(), nameof(ICircleMapElement.Fill));
            e.UpdateElement((x) => androideleent.StrokeColor = x, (mapElement.Stroke as SolidPaint).Color.AsColor(), nameof(ICircleMapElement.Stroke));
            e.UpdateElement((x) => androideleent.StrokeWidth = x, (float)mapElement.StrokeThickness, nameof(ICircleMapElement.StrokeThickness));
            
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
        public static void UpdateElement<T>(this PropertyChangedEventArgs e , Action<T> val, T setVal, string PropertyName)
        {
            if (e.PropertyName == PropertyName)
            {
                val.Invoke(setVal);
            }
        }
    }
}
