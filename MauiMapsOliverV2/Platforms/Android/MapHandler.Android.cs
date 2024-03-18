﻿using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Java.Lang;
using MauiMapsOliverV2.Core;
using MauiMapsOliverV2.Platforms.Android.Manager;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Maps.Platform;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using Math = System.Math;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class MapHandler : ViewHandler<IMap, MapView>
	{
		bool _init = true;

		MapCallbackHandler? _mapReady;
		MapSpan? _lastMoveToRegion;
		IList? _pins;
		IList? _elements;

		ManagerFactory? _managerFactory;

		public GoogleMap? Map { get; private set; }

		static Bundle? s_bundle;

		public static Bundle? Bundle
		{
			set { s_bundle = value; }
		}

        #region Handlers

        protected override void ConnectHandler(MapView platformView)
		{
			base.ConnectHandler(platformView);
			_mapReady = new MapCallbackHandler(this);
			platformView.GetMapAsync(_mapReady);
			platformView.LayoutChange += MapViewLayoutChange;
		}

		protected override void DisconnectHandler(MapView platformView)
		{
			base.DisconnectHandler(platformView);
			platformView.LayoutChange -= MapViewLayoutChange;

			

			if (Map != null)
			{
				Map.SetOnCameraMoveListener(null);
				
				Map.MapClick -= OnMapClick;
                _managerFactory?.UnSubscribe(Map);
            }

			_mapReady = null;
		}
        protected override MapView CreatePlatformView()
		{
			MapView mapView = new MapView(Context);
			mapView.OnCreate(s_bundle);
			mapView.OnResume();
			return mapView;
		}

        internal void OnMapReady(GoogleMap map)
        {
            if (map == null)
            {
                return;
            }

            Map = map;

            map.SetOnCameraMoveListener(_mapReady);


			_managerFactory = new ManagerFactory(() => MauiContext, () => Map, () => VirtualView.Elements);

            map.MapClick += OnMapClick;


            if (VirtualView != null)
            {
                map.UpdateMapType(VirtualView);
                map.UpdateIsShowingUser(VirtualView, MauiContext);
                map.UpdateIsScrollEnabled(VirtualView);
                map.UpdateIsTrafficEnabled(VirtualView);
                map.UpdateIsZoomEnabled(VirtualView);
            }

            InitialUpdate();
        }

        

        void InitialUpdate()
        {
            if (Map == null)
                return;

            if (_init && _lastMoveToRegion != null)
            {
                MoveToRegion(_lastMoveToRegion, false);
                //if (_pins != null)
                //    AddPins(_pins);
                //if (_elements != null)
                //    AddMapElements(_elements);
                _init = false;
            }

            UpdateVisibleRegion(Map.CameraPosition.Target);
        }

        #endregion

        #region Mappers

        public static void MapMapType(IMapHandler handler, IMap map)
		{
			GoogleMap? googleMap = handler?.Map;
			googleMap?.UpdateMapType(map);
		}

		public static void MapIsShowingUser(IMapHandler handler, IMap map)
		{
			GoogleMap? googleMap = handler?.Map;
			googleMap?.UpdateIsShowingUser(map, handler?.MauiContext);
		}

		public static void MapIsScrollEnabled(IMapHandler handler, IMap map)
		{
			GoogleMap? googleMap = handler?.Map;
			googleMap?.UpdateIsScrollEnabled(map);
		}

		public static void MapIsTrafficEnabled(IMapHandler handler, IMap map)
		{
			GoogleMap? googleMap = handler?.Map;
			googleMap?.UpdateIsTrafficEnabled(map);
		}

		public static void MapIsZoomEnabled(IMapHandler handler, IMap map)
		{
			GoogleMap? googleMap = handler?.Map;
			googleMap?.UpdateIsZoomEnabled(map);
		}

		public static void MapMoveToRegion(IMapHandler handler, IMap map, object? arg)
		{
			MapSpan? newRegion = arg as MapSpan;
			if (newRegion != null)
				(handler as MapHandler)?.MoveToRegion(newRegion, true);
		}

        #endregion

        //     public static void MapPins(IMapHandler handler, IMap map)
        //     {
        //         if (handler is MapHandler mapHandler)
        //         {
        //             mapHandler.AddPins(map.Pins);
        //         }
        //     }

        //     public static void MapElements(IMapHandler handler, IMap map)
        //     {
        //(handler as MapHandler)?.polylineManager?.AddElements(map.Elements.OfType<IGeoPathMapElement>());

        //     }

        #region Collection Changed
        public void ElementsCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            e.Apply(insert: (item, _, __) => AddElement(item),
                removeAt: (item, _) => RemoveMapElement(item),
                reset: () => _managerFactory?.ClearAll());
        }

        private void AddElement(object item)
        {
            if(item is not IMapElement element)
            {
                return;
            }
            _managerFactory?.AddElement(element);
        }

        private void RemoveMapElement(object item)
        {
            if(item is not IMapElement element)
            {
                return;
            }
            _managerFactory?.RemoveElement(element);
        }

        #endregion

        

        #region Elements property changed

        //      public void UpdateMapElement(IMapElement element)
        //{
        //	switch (element)
        //	{
        //		case IGeoPathMapElement polyline:
        //			{
        //				if (element is IFilledMapElement polygon)
        //				{
        //					PolygonOnPropertyChanged(polyline);
        //				}
        //				else
        //				{
        //					PolylineOnPropertyChanged(polyline);
        //				}
        //				break;
        //			}
        //		case ICircleMapElement circle:
        //			{
        //				CircleOnPropertyChanged(circle);
        //				break;
        //			}
        //	}
        //}

        //void PolygonOnPropertyChanged(IGeoPathMapElement mauiPolygon)
        //{
        //	var nativePolygon = GetNativePolygon(mauiPolygon);

        //	if (nativePolygon == null)
        //		return;

        //	if (mauiPolygon.Stroke is SolidPaint solidPaint)
        //		nativePolygon.StrokeColor = solidPaint.Color.AsColor();

        //	if ((mauiPolygon as IFilledMapElement)?.Fill is SolidPaint solidFillPaint)
        //		nativePolygon.FillColor = solidFillPaint.Color.AsColor();

        //	nativePolygon.StrokeWidth = (float)mauiPolygon.StrokeThickness;
        //	nativePolygon.Points = mauiPolygon.Select(position => new LatLng(position.Latitude, position.Longitude)).ToList();
        //}

        //void PolylineOnPropertyChanged(IGeoPathMapElement mauiPolyline)
        //{
        //	var nativePolyline = GetNativePolyline(mauiPolyline);

        //	if (nativePolyline == null)
        //		return;

        //	if (mauiPolyline.Stroke is SolidPaint solidPaint)
        //		nativePolyline.Color = solidPaint.Color.AsColor();

        //	nativePolyline.Width = (float)mauiPolyline.StrokeThickness;
        //	nativePolyline.Points = mauiPolyline.Select(position => new LatLng(position.Latitude, position.Longitude)).ToList();
        //}


        //void CircleOnPropertyChanged(ICircleMapElement mauiCircle)
        //{
        //	var nativeCircle = GetNativeCircle(mauiCircle);

        //	if (nativeCircle == null)
        //		return;


        //	if (mauiCircle.Stroke is SolidPaint solidPaint)
        //		nativeCircle.FillColor = solidPaint.Color.AsColor();

        //	if (mauiCircle.Fill is SolidPaint solidFillPaint)
        //		nativeCircle.FillColor = solidFillPaint.Color.AsColor();

        //	nativeCircle.Center = new LatLng(mauiCircle.Center.Latitude, mauiCircle.Center.Longitude);
        //	nativeCircle.Radius = mauiCircle.Radius.Meters;
        //	nativeCircle.StrokeWidth = (float)mauiCircle.StrokeThickness;

        //}

        #endregion

        #region Get Native elements

        //      protected APolyline? GetNativePolyline(IGeoPathMapElement polyline)
        //{
        //	APolyline? targetPolyline = null;

        //	if (_polylines != null && polyline.MapElementId is string)
        //	{
        //		for (int i = 0; i < _polylines.Count; i++)
        //		{
        //			var native = _polylines[i];
        //			if (native.Id == (string)polyline.MapElementId)
        //			{
        //				targetPolyline = native;
        //				break;
        //			}
        //		}
        //	}

        //	return targetPolyline;
        //}

        //protected ACircle? GetNativeCircle(ICircleMapElement circle)
        //{
        //	ACircle? targetCircle = null;

        //	if (_circles != null && circle.MapElementId is string)
        //	{
        //		for (int i = 0; i < _circles.Count; i++)
        //		{
        //			var native = _circles[i];
        //			if (native.Id == (string)circle.MapElementId)
        //			{
        //				targetCircle = native;
        //				break;
        //			}
        //		}
        //	}

        //	return targetCircle;
        //}

        //protected APolygon? GetNativePolygon(IGeoPathMapElement polygon)
        //{
        //	APolygon? targetPolygon = null;

        //	if (_polygons != null && polygon.MapElementId is string)
        //	{
        //		for (int i = 0; i < _polygons.Count; i++)
        //		{
        //			var native = _polygons[i];
        //			if (native.Id == (string)polygon.MapElementId)
        //			{
        //				targetPolygon = native;
        //				break;
        //			}
        //		}
        //	}

        //	return targetPolygon;
        //}

        #endregion







        internal void UpdateVisibleRegion(LatLng pos)
		{
			if (Map == null)
				return;

			Projection projection = Map.Projection;
			int width = PlatformView.Width;
			int height = PlatformView.Height;
			LatLng ul = projection.FromScreenLocation(new global::Android.Graphics.Point(0, 0));
			LatLng ur = projection.FromScreenLocation(new global::Android.Graphics.Point(width, 0));
			LatLng ll = projection.FromScreenLocation(new global::Android.Graphics.Point(0, height));
			LatLng lr = projection.FromScreenLocation(new global::Android.Graphics.Point(width, height));
			double dlat = Math.Max(Math.Abs(ul.Latitude - lr.Latitude), Math.Abs(ur.Latitude - ll.Latitude));
			double dlong = Math.Max(Math.Abs(ul.Longitude - lr.Longitude), Math.Abs(ur.Longitude - ll.Longitude));
			VirtualView.VisibleRegion = new MapSpan(new Devices.Sensors.Location(pos.Latitude, pos.Longitude), dlat, dlong);
		}

		void MapViewLayoutChange(object? sender, Android.Views.View.LayoutChangeEventArgs e)
		{
			InitialUpdate();
		}

		

		void MoveToRegion(MapSpan span, bool animate)
		{
			_lastMoveToRegion = span;
			if (Map == null)
				return;

			var ne = new LatLng(span.Center.Latitude + span.LatitudeDegrees / 2,
				span.Center.Longitude + span.LongitudeDegrees / 2);
			var sw = new LatLng(span.Center.Latitude - span.LatitudeDegrees / 2,
				span.Center.Longitude - span.LongitudeDegrees / 2);
			CameraUpdate update = CameraUpdateFactory.NewLatLngBounds(new LatLngBounds(sw, ne), 0);

			try
			{
				if (animate)
				{
					Map.AnimateCamera(update);
				}
				else
				{
					Map.MoveCamera(update);
				}
			}
			catch (IllegalStateException exc)
			{
				MauiContext?.Services.GetService<ILogger<MapHandler>>()?.LogWarning(exc, $"MoveToRegion exception");
			}
		}

        #region Click Events 


  //      void OnMarkerClick(object? sender, GoogleMap.MarkerClickEventArgs e)
		//{
		//	var pin = GetPinForMarker(e.Marker);

		//	if (pin == null)
		//	{
		//		return;
		//	}

		//	// Setting e.Handled = true will prevent the info window from being presented
		//	// SendMarkerClick() returns the value of PinClickedEventArgs.HideInfoWindow
		//	bool handled = pin.SendMarkerClick();
		//	e.Handled = handled;
		//}



  //      void OnInfoWindowClick(object? sender, GoogleMap.InfoWindowClickEventArgs e)
		//{
		//	var marker = e.Marker;
		//	var pin = GetPinForMarker(marker);

		//	if (pin == null)
		//	{
		//		return;
		//	}

		//	pin.SendMarkerClick();

		//	// SendInfoWindowClick() returns the value of PinClickedEventArgs.HideInfoWindow
		//	bool hideInfoWindow = pin.SendInfoWindowClick();
		//	if (hideInfoWindow)
		//	{
		//		marker.HideInfoWindow();
		//	}
		//}

		void OnMapClick(object? sender, GoogleMap.MapClickEventArgs e) =>
			VirtualView.Clicked(new Devices.Sensors.Location(e.Point.Latitude, e.Point.Longitude));

        #endregion

        #region Pins

  //      void AddPins(IEnumerable<IMapPin> pins)
		//{
		//	//Mapper could be called before we have a Map ready 
		//	if (Map == null || MauiContext == null)
		//		return;

  //          markerManager?.AddElements(pins);
  //      }

        //protected IMapPin? GetPinForMarker(Marker marker)
        //{
        //	IMapPin? targetPin = GetElementFromNative<IMapPin>(marker,VirtualView.Pins.Cast<IMapElement>());

        //	return targetPin;
        //}




        #endregion

        #region UpdateElements


        public void UpdateMapElement(IMapElement element, PropertyChangedEventArgs e)
        {
			_managerFactory?.UpdateElement(element,e);
        }

        #endregion

        //      void ClearMapElements()
        //{
        //	if (_polylines != null)
        //	{
        //		for (int i = 0; i < _polylines.Count; i++)
        //			_polylines[i].Remove();

        //		_polylines = null;
        //	}

        //	if (_polygons != null)
        //	{
        //		for (int i = 0; i < _polygons.Count; i++)
        //			_polygons[i].Remove();

        //		_polygons = null;
        //	}

        //	if (_circles != null)
        //	{
        //		for (int i = 0; i < _circles.Count; i++)
        //			_circles[i].Remove();

        //		_circles = null;
        //	}
        //}

        #region Add map elements

        //      void AddMapElements(IList mapElements)
        //{
        //	_elements = mapElements;

        //	if (Map == null || MauiContext == null)
        //		return;

        //	foreach (var element in mapElements)
        //	{
        //		if (element is IGeoPathMapElement geoPath)
        //		{
        //			if (element is IFilledMapElement)
        //			{
        //				AddPolygon(geoPath);
        //			}
        //			else
        //			{
        //				AddPolyline(geoPath);
        //			}
        //		}
        //		if (element is ICircleMapElement circle)
        //		{
        //			AddCircle(circle);
        //		}
        //	}
        //	_elements = null;
        //}

        //void AddPolyline(IGeoPathMapElement polyline)
        //{
        //	var map = Map;
        //	if (map == null)
        //		return;

        //	if (_polylines == null)
        //		_polylines = new List<APolyline>();

        //	var options = polyline.ToHandler(MauiContext!)?.PlatformView as PolylineOptions;
        //	if (options != null)
        //	{
        //		var nativePolyline = map.AddPolyline(options);

        //		polyline.MapElementId = nativePolyline.Id;

        //		_polylines.Add(nativePolyline);
        //	}
        //}

        //void AddPolygon(IGeoPathMapElement polygon)
        //{
        //	var map = Map;
        //	if (map == null)
        //	{
        //              return;
        //          }


        //	_polygons ??= new List<APolygon>();

        //	var options = polygon.ToHandler(MauiContext!)?.PlatformView as PolygonOptions;
        //	var nativePolygon = map.AddPolygon(options);

        //	polygon.MapElementId = nativePolygon.Id;

        //	_polygons.Add(nativePolygon);
        //}

        //void AddCircle(ICircleMapElement circle)
        //{
        //	var map = Map;
        //	if (map == null)
        //		return;

        //	if (_circles == null)
        //		_circles = new List<ACircle>();

        //	var options = circle.ToHandler(MauiContext!)?.PlatformView as CircleOptions;
        //	var nativeCircle = map.AddCircle(options);

        //	circle.MapElementId = nativeCircle.Id;

        //	_circles.Add(nativeCircle);
        //}

        #endregion

        
    }

    class MapCallbackHandler : Java.Lang.Object, GoogleMap.IOnCameraMoveListener, IOnMapReadyCallback
	{
		MapHandler? _handler;
		GoogleMap? _googleMap;

		public MapCallbackHandler(MapHandler mapHandler)
		{
			_handler = mapHandler;
		}

		public void OnMapReady(GoogleMap googleMap)
		{
			_googleMap = googleMap;
			_handler?.OnMapReady(googleMap);
		}

		void GoogleMap.IOnCameraMoveListener.OnCameraMove()
		{
			if (_googleMap == null)
				return;

			_handler?.UpdateVisibleRegion(_googleMap.CameraPosition.Target);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && _handler != null)
			{
				_handler = null;
				_googleMap = null;
			}

			base.Dispose(disposing);
		}
	}

}

