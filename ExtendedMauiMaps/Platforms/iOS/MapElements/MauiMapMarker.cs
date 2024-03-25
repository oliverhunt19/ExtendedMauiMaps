using MapKit;
using MauiMapsOliverV2.IMauiMapElements;

namespace ExtendedMauiMaps.Platforms.iOS.MapElements
{
    public class MauiMapMarker : MauiMapElement<MKPointAnnotation>
    {
        public MauiMapMarker()
        {
            _title = string.Empty;
            _snippet = string.Empty;
        }

        public override string Id => throw new NotImplementedException();

        private string _title;
        public string Title
        {
            get => Element?.Title ?? _title;
            set
            {
                _title = value;
                if(Element is not null)
                    Element.Title = value;
            }
        }

        private string _snippet;
        public string Snippet
        {
            get => Element?.Subtitle ?? _snippet;
            set
            {
                _snippet = value;


                if(Element is not null)
                {
                    Element.Subtitle = value;
                    //Element.SetValueForKey(new NSString(pin.Address ?? string.Empty), new NSString(nameof(MKPointAnnotation.Subtitle)));
                }
            }
        }

        public override bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override float ZIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //private LatLng _position;
        //public LatLng Position
        //{
        //    get => Element?.Coordinate ?? _position;
        //    set
        //    {
        //        _position = value;
        //        if(Element is not null)
        //            Element.SetCoordinate(value);
        //    }
        //}

        //private float _alpha = 1f;
        //public float Alpha
        //{
        //    get => Element?.Alpha ?? _alpha;
        //    set
        //    {
        //        _alpha = value;
        //        if(Element is not null)
        //            Element.Al = value;
        //    }
        //}

        //private bool _draggable;
        //public bool Draggable
        //{
        //    get => Element?.Draggable ?? _draggable;
        //    set
        //    {
        //        _draggable = value;
        //        if(Element is not null)
        //            Element.Draggable = value;
        //    }
        //}

        //private bool _visible = true;
        //public override bool Visible
        //{
        //    get => Element?.Visible ?? _visible;
        //    set
        //    {
        //        _visible = value;
        //        if(Element is not null)
        //            Element.Visible = value;
        //    }
        //}

        //private float _zIndex;
        //public override float ZIndex
        //{
        //    get => Element?.ZIndex ?? _zIndex;
        //    set
        //    {
        //        _zIndex = value;
        //        if(Element is not null)
        //            Element.ZIndex = value;
        //    }
        //}

        //private float _rotation;
        //public float Rotation
        //{
        //    get => Element?.Rotation ?? _rotation;
        //    set
        //    {
        //        _rotation = value;
        //        if(Element is not null)
        //            Element.Rotation = value;
        //    }
        //}

        //private (float u, float v) _anchor = (0.5f, 1.0f);
        //public (float u, float v) Anchor
        //{
        //    get => _anchor;
        //    set
        //    {
        //        _anchor = value;
        //        Element?.SetAnchor(_anchor.u, _anchor.v);
        //    }
        //}

        //private (float u, float v) _infoWindowAnchor = (0.5f, 0.0f);
        //public (float u, float v) InfoWindowAnchor
        //{
        //    get => _infoWindowAnchor;
        //    set
        //    {
        //        _infoWindowAnchor = value;
        //        Element?.SetInfoWindowAnchor(_anchor.u, _anchor.v);
        //    }
        //}

        //private bool _flatten;
        //public bool Flatten
        //{
        //    get => Element?.Flat ?? _flatten;
        //    set
        //    {
        //        _flatten = value;
        //        if(Element is not null)
        //        {
        //            Element.Flat = value;
        //        }
        //    }
        //}


        protected override void RemoveFromMapInternal()
        {
            throw new NotImplementedException();
        }

        protected override MKPointAnnotation AddToMapsInternal()
        {
            return new MKPointAnnotation();
        }
    }
}
