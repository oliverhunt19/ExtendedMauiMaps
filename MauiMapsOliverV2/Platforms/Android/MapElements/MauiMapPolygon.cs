using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.IMauiMapElements;
using Microsoft.Maui.Graphics.Platform;
using APolygon = Android.Gms.Maps.Model.Polygon;
using Color = Android.Graphics.Color;

namespace ExtendedMauiMaps.Platforms.Android.MapElements
{
    public class MauiMapPolygon : MauiFilledMapElement<APolygon>
    {
        public MauiMapPolygon()
        {
            _points = new List<LatLng>();
        }

        private IList<LatLng> _points;
        public IList<LatLng> Points
        {
            get
            {
                return Element?.Points ?? _points;
            }
            set
            {
                _points = value;
                if(Element is not null)
                {
                    Element.Points = value;
                }

            }
        }

        private bool _visible = true;
        public override bool Visible
        {
            get => Element?.Visible ?? _visible;
            set
            {
                _visible = value;
                if(Element is not null)
                    Element.Visible = value;
            }
        }

        private float _zIndex;
        public override float ZIndex
        {
            get => Element?.ZIndex ?? _zIndex;
            set
            {
                _zIndex = value;
                if(Element is not null)
                    Element.ZIndex = value;
            }
        }

        public override string Id => Element?.Id ?? "";

        private Microsoft.Maui.Graphics.Color _fillColour = Colors.Transparent;
        public override Microsoft.Maui.Graphics.Color FillColour
        {
            get => Element is not null ? new Color(Element.FillColor).AsColor() : _fillColour;
            set
            {
                _fillColour = value;
                if(ElementHasValue)
                {
                    Element!.FillColor = _fillColour.AsColor();
                }
            }
        }

        private bool _clickable;
        public override bool Clickable
        {
            get => Element?.Clickable ?? _clickable;
            set
            {
                _clickable = value;
                if(ElementHasValue)
                {
                    Element!.Clickable = value;
                }
            }
        }

        private Microsoft.Maui.Graphics.Color _strokeColour = Colors.Black;
        public override Microsoft.Maui.Graphics.Color StrokeColor
        {
            get => ElementHasValue ? new Color(Element!.StrokeColor).AsColor() : _strokeColour;
            set
            {
                _strokeColour = value;
                if(ElementHasValue)
                {
                    Element!.StrokeColor = _strokeColour.AsColor();
                }
            }
        }

        private double _strokeWidth = 5;
        public override double StrokeWidth
        {
            get => Element?.StrokeWidth ?? _strokeWidth;
            set
            {
                _strokeWidth = value;
                if(ElementHasValue)
                {
                    Element!.StrokeWidth = (float) value;
                }
            }
        }

        //public int ReplacePointsWith(IEnumerable<LatLng> points)
        //{
        //    ((ObservableRangeCollection<LatLng>)Points).ReplaceRange(points);
        //    return Points.Count;
        //}

        protected override APolygon AddToMapsInternal(GoogleMap map)
        {
            var options = new PolygonOptions();
            //Java.Util.ArrayList arrayList = new Java.Util.ArrayList(new List<double>());
            //options.AddHole(arrayList);
            options.InvokeStrokeWidth((float) StrokeWidth);
            options.InvokeStrokeColor(StrokeColor.AsColor());
            options.InvokeFillColor(FillColour.AsColor());
            // Will throw an exception when added to the map if Points is empty
            if(!Points.Any())
            {
                options.Points.Add(new LatLng(0, 0));
            }
            else
            {
                foreach(var i in Points)
                {
                    options.Points.Add(i);
                }
            }
            options.Visible(Visible);
            options.InvokeZIndex(ZIndex);
            options.Clickable(Clickable);
            return map.AddPolygon(options);
        }

        protected override void RemoveFromMapInternal()
        {
            Element?.Remove();
        }
    }
}