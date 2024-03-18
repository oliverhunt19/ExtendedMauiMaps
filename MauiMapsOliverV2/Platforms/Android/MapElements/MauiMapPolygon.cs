﻿using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using APolygon = Android.Gms.Maps.Model.Polygon;
using Color = Android.Graphics.Color;

namespace MauiMapsOliverV2.Platforms.Android.MapElements
{
    public class MauiMapPolygon : MauiMapElement<APolygon>
    {
        public MauiMapPolygon()
        {
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

        private ObservableRangeCollection<LatLng> _points;
        public IList<LatLng> Points
        {
            get
            {
                if (_points is null)
                {
                    _points = new ObservableRangeCollection<LatLng>();
                    _points.CollectionChanged += (sender, args) =>
                    {
                        if (Element is not null)
                            Element.Points = new List<LatLng>(_points);
                    };
                }

                return _points;
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


        public int ReplacePointsWith(IEnumerable<LatLng> points)
        {
            ((ObservableRangeCollection<LatLng>)Points).ReplaceRange(points);
            return Points.Count;
        }

        protected override APolygon AddToMapsInternal(GoogleMap map)
        {
            var options = new PolygonOptions();
            options.InvokeStrokeWidth(StrokeWidth);
            options.InvokeStrokeColor(StrokeColor);
            options.InvokeFillColor(FillColor);
            // Will throw an exception when added to the map if Points is empty
            if(!Points.Any())
            {
                options.Points.Add(new LatLng(0, 0));
            }
            else
            {
                foreach(var i in Points)
                    options.Points.Add(i);
            }
            options.Visible(Visible);
            options.InvokeZIndex(ZIndex);
            return map.AddPolygon(options);
        }

        protected override void RemoveFromMapInternal()
        {
            Element?.Remove();
        }
    }
}