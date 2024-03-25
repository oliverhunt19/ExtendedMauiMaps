using CommunityToolkit.Maui.Maps.Handlers;
using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Primitives;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Web.WebView2.Core;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using Windows.Devices.Geolocation;
using IMap = ExtendedMauiMaps.Core.IMap;

namespace ExtendedMauiMaps.Handlers.Map
{
    public partial class MapHandler : ViewHandler<IMap, MauiWebView>
	{
        internal static string? MapsKey;
        MapSpan? regionToGo;

        readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        protected override MauiWebView CreatePlatformView()
		{
            if (string.IsNullOrEmpty(MapsKey))
            {
                throw new InvalidOperationException("You need to specify a Bing Maps Key");
            }

            var mapPage = GetMapHtmlPage(MapsKey);
            var webView = new MauiWebView();
            webView.NavigationCompleted += WebViewNavigationCompleted;
            webView.WebMessageReceived += WebViewWebMessageReceived;
            webView.LoadHtml(mapPage, null);
            return webView;
        }

        /// <inheritdoc />
        protected override void DisconnectHandler(MauiWebView platformView)
        {
            platformView.NavigationCompleted -= WebViewNavigationCompleted;
            platformView.WebMessageReceived -= WebViewWebMessageReceived;

            base.DisconnectHandler(platformView);
        }

        void WebViewNavigationCompleted(WebView2 sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            // Update initial properties when our page is loaded
            Mapper.UpdateProperties(this, VirtualView);

            if (regionToGo != null)
            {
                MapMoveToRegion(this, VirtualView, regionToGo);
            }
        }

        private void WebViewWebMessageReceived(WebView2 sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            // For some reason the web message is empty
            if (string.IsNullOrEmpty(args.WebMessageAsJson))
            {
                return;
            }

            var eventMessage = JsonSerializer.Deserialize<EventMessage>(args.WebMessageAsJson, jsonSerializerOptions);

            // The web message (or it's ID) could not be deserialized to something we recognize
            if (eventMessage is null || !Enum.TryParse<EventIdentifier>(eventMessage.Id, true, out var eventId))
            {
                return;
            }

            var payloadAsString = eventMessage.Payload?.ToString();

            // The web message does not have a payload
            if (string.IsNullOrWhiteSpace(payloadAsString))
            {
                return;
            }

            switch (eventId)
            {
                case EventIdentifier.BoundsChanged:
                    var mapRect = JsonSerializer.Deserialize<Bounds>(payloadAsString, jsonSerializerOptions);
                    if (mapRect?.Center is not null)
                    {
                        VirtualView.VisibleRegion = new MapSpan(new Location(mapRect.Center.Latitude, mapRect.Center.Longitude),
                            mapRect.Height, mapRect.Width);
                    }
                    break;
                case EventIdentifier.MapClicked:
                    var clickedLocation = JsonSerializer.Deserialize<Location>(payloadAsString,
                        jsonSerializerOptions);
                    if (clickedLocation is not null)
                    {
                        VirtualView.Clicked(clickedLocation);
                    }
                    break;

                case EventIdentifier.InfoWindowClicked:
                    var clickedInfoWindowWebView = JsonSerializer.Deserialize<InfoWindow>(payloadAsString,
                        jsonSerializerOptions);
                    var clickedInfoWindowWebViewId = clickedInfoWindowWebView?.InfoWindowMarkerId;

                    if (!string.IsNullOrEmpty(clickedInfoWindowWebViewId))
                    {
                        var clickedPin = VirtualView.Pins.SingleOrDefault(p => p.MapElementId?.ToString()?.Equals(clickedInfoWindowWebViewId) ?? false);

                        var hideInfoWindow = clickedPin?.SendInfoWindowClick();
                        if (hideInfoWindow is not false)
                        {
                            CallJSMethod(PlatformView, "hideInfoWindow();");
                        }
                    }
                    break;

                case EventIdentifier.PinClicked:
                    var clickedPinWebView = JsonSerializer.Deserialize<IMapPin>(payloadAsString, jsonSerializerOptions);
                    var clickedPinWebViewId = clickedPinWebView?.MapElementId?.ToString();

                    if (!string.IsNullOrEmpty(clickedPinWebViewId))
                    {
                        var clickedPin = VirtualView.Pins.SingleOrDefault(p => p?.MapElementId?.ToString()?.Equals(clickedPinWebViewId) ?? false);

                        var hideInfoWindow = clickedPin?.SendElementClick();
                        if (hideInfoWindow is not false)
                        {
                            CallJSMethod(PlatformView, "hideInfoWindow();");
                        }
                    }
                    break;
            }
        }

        private static void CallJSMethod(MauiWebView platformWebView, string script)
        {
            if (platformWebView.CoreWebView2 != null)
            {
                platformWebView.DispatcherQueue.TryEnqueue(async () => await platformWebView.ExecuteScriptAsync(script));
            }
        }

		public static void MapMapType(MapHandler handler, IMap map)
		{
            CallJSMethod(handler.PlatformView, $"setMapType('{map.MapType}');");
        }

		public static void MapIsZoomEnabled(MapHandler handler, IMap map)
		{
            CallJSMethod(handler.PlatformView, $"disableMapZoom({(!map.IsZoomEnabled).ToString().ToLower()});");
        }

		public static void MapIsScrollEnabled(MapHandler handler, IMap map)
		{
            CallJSMethod(handler.PlatformView, $"disablePanning({(!map.IsScrollEnabled).ToString().ToLower()});");
        }

		public static void MapIsTrafficEnabled(MapHandler handler, IMap map)
		{
            CallJSMethod(handler.PlatformView, $"disableTraffic({(!map.IsTrafficEnabled).ToString().ToLower()});");
        }

		public static async void MapIsShowingUser(MapHandler handler, IMap map)
		{
            if (map.IsShowingUser)
            {
                var location = await GetCurrentLocation();
                if (location != null)
                {
                    CallJSMethod(handler.PlatformView, $"addLocationPin({location.Latitude.ToString(CultureInfo.InvariantCulture)},{location.Longitude.ToString(CultureInfo.InvariantCulture)});");
                }
            }
            else
            {
                CallJSMethod(handler.PlatformView, "removeLocationPin();");
            }
        }

        static async Task<Location?> GetCurrentLocation()
        {
            var geoLocator = new Geolocator();
            var position = await geoLocator.GetGeopositionAsync();
            return new Location(position.Coordinate.Latitude, position.Coordinate.Longitude);
        }

		public static void MapMoveToRegion(MapHandler handler, IMap map, object? arg)
		{
            var newRegion = arg as MapSpan;
            if (newRegion == null)
            {
                return;
            }

            handler.regionToGo = newRegion;

            CallJSMethod(handler.PlatformView, $"setRegion({newRegion.Center.Latitude.ToString(CultureInfo.InvariantCulture)},{newRegion.Center.Longitude.ToString(CultureInfo.InvariantCulture)});");
        }

		public static void MapPins(MapHandler handler, IMap map)
		{
            CallJSMethod(handler.PlatformView, "removeAllPins();");

            foreach (var pin in map.Pins)
            {
                CallJSMethod(handler.PlatformView, $"addPin({pin.Location.Latitude.ToString(CultureInfo.InvariantCulture)}," +
                    $"{pin.Location.Longitude.ToString(CultureInfo.InvariantCulture)},'{pin.Label}', '{pin.Address}', '{pin?.MapElementId}');");
            }
        }

		public static void MapElements(IMapHandler handler, IMap map) => throw new NotImplementedException();

		public void UpdateMapElement(IMapElement element, PropertyChangedEventArgs e) => throw new NotImplementedException();

        public void ElementsCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }


        static string GetMapHtmlPage(string key)
        {
            var str = @$"<!DOCTYPE html>
				<html>
					<head>
						<title></title>
						<meta http-equiv=""Content-Security-Policy"" content=""default-src 'self' data: gap: https://ssl.gstatic.com 'unsafe-eval' 'unsafe-inline' https://*.bing.com https://*.virtualearth.net; style-src 'self' 'unsafe-inline' https://*.bing.com https://*.virtualearth.net; media-src *"">
						<meta name=""viewport"" content=""user-scalable=no, initial-scale=1, maximum-scale=1, minimum-scale=1, width=device-width"">
						<script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?key={key}'></script>";
            str += @"<script type='text/javascript'>
			                var map;
							var locationPin;
							var trafficManager;
							var infobox;

			                function loadMap() {
			                    map = new Microsoft.Maps.Map(document.getElementById('myMap'), {
									disableBirdseye : true,
								//	disableZooming: true,
								//	disablePanning: true,
									showScalebar: false,
									showLocateMeButton: false,
									showDashboard: false,
									showTermsLink: false,
									showTrafficButton: false
								});
								loadTrafficModule();
								Microsoft.Maps.Events.addHandler(map, 'viewrendered', function () { var bounds = map.getBounds(); invokeHandlerAction('BoundsChanged', bounds); });

								Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
									if (!e.isPrimary) {
										return;
									}

									var clickedLocation = {
										latitude: e.location.latitude,
										longitude: e.location.longitude
									};

									invokeHandlerAction('MapClicked', clickedLocation);
								});

								infobox = new Microsoft.Maps.Infobox(map.getCenter(), {
									visible: false
								});
								infobox.setMap(map);
								Microsoft.Maps.Events.addHandler(infobox, 'click', function (args) {
									// If not visible, we assume the user pressed the close button
									if (args.target.getVisible() == false)
										return;

									var infoWindow = {
										infoWindowMarkerId: infobox.infoWindowMarkerId									
									};

									invokeHandlerAction('InfoWindowClicked', infoWindow);
								});
			                }
							
							function loadTrafficModule()
							{
								Microsoft.Maps.loadModule('Microsoft.Maps.Traffic', function () {
									 trafficManager = new Microsoft.Maps.Traffic.TrafficManager(map);
								});
							}

							function disableTraffic(disable)
							{
								if(disable)
									trafficManager.hide();
								else
									trafficManager.show();
							}

							function disableMapZoom(disable)
							{
								map.setOptions({
									disableZooming: disable,
								});
							}
							
							function disablePanning(disable)
							{
								map.setOptions({
									disablePanning: disable,
								});
							}
			
							function setMapType(mauiMapType)
							{
								var mapTypeID = Microsoft.Maps.MapTypeId.road;
								switch(mauiMapType) {
								  case 'Street':
								    mapTypeID = Microsoft.Maps.MapTypeId.road;
								    break;
								  case 'Satellite':
								    mapTypeID = Microsoft.Maps.MapTypeId.aerial;
								    break;
								  case 'Hybrid':
								    mapTypeID = Microsoft.Maps.MapTypeId.aerial;
									break;
								  default:
									mapTypeID = Microsoft.Maps.MapTypeId.road;
								}
								map.setView({
									mapTypeId: mapTypeID
								});
							}

							function setRegion(latitude, longitude)
							{
								map.setView({
									center: new Microsoft.Maps.Location(latitude, longitude),
								});
							}

							function addLocationPin(latitude, longitude)
							{
								var location = new Microsoft.Maps.Location(latitude, longitude);
								locationPin = new Microsoft.Maps.Pushpin(location, null);
								map.entities.push(locationPin);
								map.setView({
									center: location
								});
							}
					
							function removeLocationPin()
							{
								if (locationPin != null)
								{
									map.entities.remove(locationPin);
									locationPin = null;
								}
							}

							function removeAllPins()
							{
								map.entities.clear();
								locationPin = null;
							}

							function addPin(latitude, longitude, label, address, id)
							{
								var location = new Microsoft.Maps.Location(latitude, longitude);
								var pin = new Microsoft.Maps.Pushpin(location, {
								            title: label,
											subTitle: address
								        });

								pin.markerId = id;
								map.entities.push(pin);
								Microsoft.Maps.Events.addHandler(pin, 'click', function (e) 
								{
									if (e.targetType !== 'pushpin')
										return;

									//Set the infobox options with the metadata of the pushpin.
									infobox.setOptions({
										location: e.target.getLocation(),
										title: e.target.getTitle(),
										description: e.target.getSubTitle(),
										visible: true
									});

									infobox.infoWindowMarkerId = id;

									var clickedPin = {
										label: e.target.getTitle(),
										address: e.target.getSubTitle(),
										location: e.target.getLocation(),
										markerId: e.target.markerId
									};
									invokeHandlerAction('PinClicked', clickedPin);
								});
							}

							function invokeHandlerAction(id, data)
							{
								var eventMessage = {
									id: id,
									payload: data
								};

								window.chrome.webview.postMessage(eventMessage);
							}

							function hideInfoWindow()
							{
								infobox.setOptions({
									visible: false
								});
							}
						</script>
						<style>
							body, html{
								padding:0;
								margin:0;
							}
						</style>
					</head>
					<body onload='loadMap();'>
						<div id=""myMap""></div>
					</body>
				</html>";
            return str;
        }

    }
}
