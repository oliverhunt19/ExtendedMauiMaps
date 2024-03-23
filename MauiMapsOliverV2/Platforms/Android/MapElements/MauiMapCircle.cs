using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MauiMapsOliverV2.IMauiMapElements;
using Microsoft.Maui.Graphics.Platform;
using ACircle = Android.Gms.Maps.Model.Circle;
using Color = Android.Graphics.Color;

namespace MauiMapsOliverV2.Platforms.Android.MapElements
{
    public class MauiMapCircle : MauiFilledMapElement<ACircle>
    {
        public MauiMapCircle()
        {
        }

        protected override ACircle AddToMapsInternal(GoogleMap map)
        {
            var options = new CircleOptions();
            options.InvokeCenter(Center);
            options.InvokeRadius(Radius);
            options.InvokeStrokeWidth((float) StrokeWidth);
            options.InvokeStrokeColor(StrokeColor.AsColor());
            options.InvokeFillColor(FillColour.AsColor());
            options.Visible(Visible);
            options.InvokeZIndex(ZIndex);
            return map.AddCircle(options);
        }

        private LatLng _center = new LatLng(0,0);
        public LatLng Center
        {
            get => Element?.Center ?? _center;
            set
            {
                _center = value;
                if (Element is not null)
                    Element.Center = value;
            }
        }

        private double _radius;
        public double Radius
        {
            get => Element?.Radius ?? _radius;
            set
            {
                _radius = value;
                if (Element is not null)
                    Element.Radius = value;
            }
        }

        private bool _visible = true;
        public override bool Visible
        {
            get => Element?.Visible ?? _visible;
            set
            {
                _visible = value;
                if (Element is not null)
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
                if (Element is not null)
                    Element.ZIndex = value;
            }
        }

        public override string Id => Element?.Id ?? "";

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

        private Microsoft.Maui.Graphics.Color _strokeColor = Colors.Black;
        public override Microsoft.Maui.Graphics.Color StrokeColor
        {
            get
            {
                return Element is not null ? new Color(Element.StrokeColor).AsColor() : _strokeColor;
            }
            set
            {
                _strokeColor= value;
                if(Element is not null)
                {
                    Element.StrokeColor = value.AsColor();
                }
            }
        }

        private double _strokeWidth;
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

        private Microsoft.Maui.Graphics.Color _fillColor = Colors.Transparent;
        public override Microsoft.Maui.Graphics.Color FillColour
        {
            get
            {
                return Element is not null ? new Color(Element.FillColor).AsColor() : _fillColor;
            }
            set
            {
                _fillColor= value;
                if(ElementHasValue)
                {
                    Element!.FillColor = value.AsColor();
                }
            }
        }

        protected override void RemoveFromMapInternal()
        {
            Element?.Remove();
        }
    }
}