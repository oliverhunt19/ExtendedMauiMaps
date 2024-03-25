using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics.Drawables;
using MauiMapsOliverV2.IMauiMapElements;

namespace ExtendedMauiMaps.Platforms.Android.MapElements
{
    public class MauiMapMarker : MauiMapElement<Marker>
    {
        readonly Func<IMauiContext?> GetMauiContext;
        public MauiMapMarker(Func<IMauiContext?> getMauiContext)
        {
            GetMauiContext = getMauiContext;
            _title = "";
            _snippet = "";
            _position = new LatLng(0, 0);
        }



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
            get => Element?.Snippet ?? _snippet;
            set
            {
                _snippet = value;
                if(Element is not null)
                    Element.Snippet = value;
            }
        }

        private LatLng _position;
        public LatLng Position
        {
            get => Element?.Position ?? _position;
            set
            {
                _position = value;
                if(Element is not null)
                    Element.Position = value;
            }
        }

        private float _alpha = 1f;
        public float Alpha
        {
            get => Element?.Alpha ?? _alpha;
            set
            {
                _alpha = value;
                if(Element is not null)
                    Element.Alpha = value;
            }
        }

        private bool _draggable;
        public bool Draggable
        {
            get => Element?.Draggable ?? _draggable;
            set
            {
                _draggable = value;
                if(Element is not null)
                    Element.Draggable = value;
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

        private float _rotation;
        public float Rotation
        {
            get => Element?.Rotation ?? _rotation;
            set
            {
                _rotation = value;
                if(Element is not null)
                    Element.Rotation = value;
            }
        }

        private (float u, float v) _anchor = (0.5f, 1.0f);
        public (float u, float v) Anchor
        {
            get => _anchor;
            set
            {
                _anchor = value;
                Element?.SetAnchor(_anchor.u, _anchor.v);
            }
        }

        private (float u, float v) _infoWindowAnchor = (0.5f, 0.0f);
        public (float u, float v) InfoWindowAnchor
        {
            get => _infoWindowAnchor;
            set
            {
                _infoWindowAnchor = value;
                Element?.SetInfoWindowAnchor(_anchor.u, _anchor.v);
            }
        }

        private bool _flatten;
        public bool Flatten
        {
            get => Element?.Flat ?? _flatten;
            set
            {
                _flatten = value;
                if(Element is not null)
                {
                    Element.Flat = value;
                }
            }
        }

        private ImageSource _icon;
        public ImageSource Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                SetAImageMarkerIcon(_icon,(x)=> Element?.SetIcon(x));
            }
        }

        private void SetAImageMarkerIcon(ImageSource imageSource, Action<BitmapDescriptor> setBitmapDescriptor)
        {
            IMauiContext? mauiContext = GetMauiContext.Invoke();
            if(mauiContext is not null)
            {
                imageSource.LoadImage(mauiContext, result =>
                {
                    if(result?.Value is BitmapDrawable bitmapDrawable)
                    {
                        BitmapDescriptor bitmapDescriptor = BitmapDescriptorFactory.FromBitmap(bitmapDrawable.Bitmap);
                        setBitmapDescriptor.Invoke(bitmapDescriptor);
                    }
                });
            }
        }

        public override string Id => Element?.Id ?? "";

        public bool IsInfoWindowShown => Element?.IsInfoWindowShown ?? false;
        public void ShowInfoWindow() => Element?.ShowInfoWindow();
        public void HideInfoWindow() => Element?.HideInfoWindow();



        protected override Marker AddToMapsInternal(GoogleMap map)
        {
            var options = new MarkerOptions();
            options.SetTitle(Title);
            options.SetSnippet(Snippet);
            options.SetPosition(Position);
            options.SetAlpha(Alpha);
            options.Visible(Visible);
            options.Draggable(Draggable);
            options.InvokeZIndex(ZIndex);
            options.SetRotation(Rotation);
            options.Anchor(Anchor.u, Anchor.v);
            options.InfoWindowAnchor(InfoWindowAnchor.u, InfoWindowAnchor.v);
            SetAImageMarkerIcon(Icon, (x) => options.SetIcon(x));
            options.Flat(Flatten);
            return map.AddMarker(options);
        }

        protected override void RemoveFromMapInternal()
        {
            Element?.Remove();
        }
    }
}