﻿using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ACircle = Android.Gms.Maps.Model.Circle;
using Color = Android.Graphics.Color;

namespace MauiMapsOliverV2.Platforms.Android.MapElements
{
    public class MauiMapCircle : MauiStrokeMapElement<ACircle>
    {
        public MauiMapCircle()
        {
        }

        protected override ACircle AddToMapsInternal(GoogleMap map)
        {
            var options = new CircleOptions();
            options.InvokeCenter(Center);
            options.InvokeRadius(Radius);
            options.InvokeStrokeWidth(StrokeWidth);
            options.InvokeStrokeColor(StrokeColor);
            options.InvokeFillColor(FillColor);
            options.Visible(Visible);
            options.InvokeZIndex(ZIndex);
            return map.AddCircle(options);
        }

        private LatLng _center;
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

        private float _strokeWidth;
        public float StrokeWidth
        {
            get => Element?.StrokeWidth ?? _strokeWidth;
            set
            {
                _strokeWidth = value;
                if (Element is not null)
                    Element.StrokeWidth = value;
            }
        }

        private Color _strokeColor;
        public Color StrokeColor
        {
            get => Element is not null ? new Color(Element.StrokeColor) : _strokeColor;
            set
            {
                _strokeColor = value;
                if (Element is not null)
                    Element.StrokeColor = value;
            }
        }

        private Color _fillColor;
        public Color FillColor
        {
            get => Element is not null ? new Color(Element.FillColor) : _fillColor;
            set
            {
                _fillColor = value;
                if (Element is not null)
                    Element.FillColor = value;
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

        public override string Id => Element?.Id;

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

        protected override void RemoveFromMapInternal()
        {
            Element?.Remove();
        }
    }
}