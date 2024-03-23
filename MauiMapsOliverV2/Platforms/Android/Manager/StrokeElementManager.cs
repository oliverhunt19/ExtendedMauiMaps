using Android.Gms.Maps;
using ExtendedMauiMaps.Core;
using Microsoft.Maui.Graphics.Platform;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    internal abstract class StrokeElementManager<TAndroid, TAndroidOptions, TMapElement> : ElementManager<TAndroid, TAndroidOptions, TMapElement>
        where TAndroid : Java.Lang.Object
        where TAndroidOptions : class
        where TMapElement : IMapElement
    {
        private ClickedPolyline? clickedPolyline;

        protected StrokeElementManager(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IEnumerable<TMapElement>> mapElementClicked) : base(mauiContext, map, mapElementClicked)
        {
        }

        protected void ShapeClicked(TAndroid nativeElement)
        {
            bool handled = ElementClicked(nativeElement);

            clickedPolyline?.Unclicked();
            if(!handled)
            {
                clickedPolyline = GetClickedPolyline(nativeElement);
                clickedPolyline.Clicked();
            }
        }

        protected abstract ClickedPolyline GetClickedPolyline(TAndroid element);

        protected abstract class ClickedPolyline
        {
            private readonly TAndroid Polyline;

            private int? OriginalColour;

            public ClickedPolyline(TAndroid previous)
            {
                Polyline = previous;
            }

            public void Clicked()
            {
                OriginalColour = GetColour(Polyline);
                SetColour(Polyline, Colors.Red.AsColor());
            }

            public void Unclicked()
            {
                SetColour(Polyline, OriginalColour ?? throw new InvalidOperationException("This should only be called after you have clicked"));
            }

            protected abstract int GetColour(TAndroid element);

            protected abstract void SetColour(TAndroid element, int Colour);

        }
    }
}
