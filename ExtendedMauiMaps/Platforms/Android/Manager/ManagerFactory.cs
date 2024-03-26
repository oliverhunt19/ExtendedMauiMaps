using Android.Gms.Maps;
using ExtendedMauiMaps.Core;

namespace ExtendedMauiMaps.Platforms.Android.Manager
{
    public class ManagerFactory
    {
        PolylineManager polylineManager;
        MarkerManager markerManager;
        CircleManager circleManager;
        PolygonManager polygonManager;

        protected readonly Func<IMauiContext?> GetMauiContext;

        protected readonly Func<GoogleMap> GetGoogleMap;

        protected readonly Func<IList<IMapElement>> GetMapElements;

        GoogleMap Map => GetGoogleMap.Invoke();

        public ManagerFactory(Func<IMauiContext?> mauiContext, Func<GoogleMap> map, Func<IList<IMapElement>> GetMapElements)
        {
            GetMauiContext = mauiContext;
            GetGoogleMap = map;
            this.GetMapElements = GetMapElements;

            polygonManager = new PolygonManager(mauiContext, map);
            polylineManager = new PolylineManager(mauiContext, map);
            circleManager = new CircleManager(mauiContext, map);
            markerManager = new MarkerManager(mauiContext, map);

            Map.PolylineClick += polylineManager.Map_PolylineClick;
            Map.PolygonClick += polygonManager.Map_PolygonClick;
            Map.CircleClick += circleManager.Map_CircleClick;

            Map.MarkerClick += markerManager.OnMarkerClick;
            Map.InfoWindowClick += markerManager.OnInfoWindowClick;
            Map.MarkerDrag += markerManager.Map_MarkerDrag;
            Map.MarkerDragStart += markerManager.Map_MarkerDragStart;
            Map.MarkerDragEnd += markerManager.Map_MarkerDragEnd;
        }

        private IList<T> GetMapElementOfType<T>()
            where T : IMapElement
        {
            return GetMapElements.Invoke().OfType<T>().ToList();
        }

        public void AddElements(IEnumerable<IMapElement> mapElements)
        {
            foreach(var mapElement in mapElements)
            {
                AddElement(mapElement);
            }
        }

        public void ClearAll()
        {
            polygonManager.ClearAll();
            polylineManager.ClearAll();
            circleManager.ClearAll();
            markerManager.ClearAll();
        }

        public void RemoveElements(IEnumerable<IMapElement> mapElements)
        {
            foreach(var mapElement in mapElements)
            {
                RemoveElement(mapElement);
            }
        }

        public void AddElement(IMapElement element)
        {
            switch(element)
            {
                case ICircleMapElement circle:
                {
                    circleManager?.AddElement(circle);
                    break;
                }
                case IPolylineMapElement circle:
                {
                    polylineManager?.AddElement(circle);
                    break;
                }
                case IPolygonMapElement circle:
                {
                    polygonManager?.AddElement(circle);
                    break;
                }
                case IMapPin circle:
                {
                    markerManager?.AddElement(circle);
                    break;
                }
            }
        }

        public void RemoveElement(IMapElement element)
        {
            switch(element)
            {
                case ICircleMapElement circle:
                {
                    circleManager?.RemoveElement(circle);
                    break;
                }
                case IPolylineMapElement circle:
                {
                    polylineManager?.RemoveElement(circle);
                    break;
                }
                case IPolygonMapElement circle:
                {
                    polygonManager?.RemoveElement(circle);
                    break;
                }
                case IMapPin circle:
                {
                    markerManager?.RemoveElement(circle);
                    break;
                }
            }
        }

        //public void UpdateElement(IMapElement mapElement, PropertyChangedEventArgs e)
        //{
        //    switch(mapElement)
        //    {
        //        case ICircleMapElement circle:
        //        {
        //            circleManager?.ElementUpdated(circle,e);
        //            break;
        //        }
        //        case IPolylineMapElement circle:
        //        {
        //            polylineManager?.ElementUpdated(circle, e);
        //            break;
        //        }
        //        case IPolygonMapElement circle:
        //        {
        //            polygonManager?.ElementUpdated(circle, e);
        //            break;
        //        }
        //        case IMapPin circle:
        //        {
        //            markerManager?.ElementUpdated(circle, e);
        //            break;
        //        }
        //    }
        //}

        public void UnSubscribe(GoogleMap Map)
        {
            if(markerManager is not null)
            {
                Map.MarkerClick -= markerManager.OnMarkerClick;
                Map.InfoWindowClick -= markerManager.OnInfoWindowClick;
                Map.MarkerDrag -= markerManager.Map_MarkerDrag;
                Map.MarkerDragStart -= markerManager.Map_MarkerDragStart;
                Map.MarkerDragEnd -= markerManager.Map_MarkerDragEnd;
            }
            if(polylineManager is not null)
            {
                Map.PolylineClick -= polylineManager.Map_PolylineClick;
            }
            if(polygonManager is not null)
            {
                Map.PolygonClick -= polygonManager.Map_PolygonClick;
            }
            if(circleManager is not null)
            {
                Map.CircleClick -= circleManager.Map_CircleClick;
            }
        }


    }
}
