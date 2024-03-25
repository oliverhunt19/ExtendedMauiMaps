using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMauiMaps.Handlers.Map;
using ExtendedMauiMaps.Primitives;
using Microsoft.Extensions.Logging;
using IMap = ExtendedMauiMaps.Core.IMap;

namespace ExtendedMauiMaps.Platforms.Android
{
    public static class MapExtensions
    {
        public static void UpdateMapType(this GoogleMap googleMap, IMap map)
        {
            if(googleMap == null)
                return;

            googleMap.MapType = map.MapType switch
            {
                MapType.Street => GoogleMap.MapTypeNormal,
                MapType.Satellite => GoogleMap.MapTypeSatellite,
                MapType.Hybrid => GoogleMap.MapTypeHybrid,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public static void UpdateIsShowingUser(this GoogleMap googleMap, IMap map, IMauiContext? mauiContext)
        {
            if(googleMap == null)
                return;

            if(mauiContext?.Context == null)
                return;

            googleMap.SetIsShowingUser(map, mauiContext).FireAndForget();
        }

        public static async void FireAndForget(
            this Task task,
            Action<Exception>? errorCallback = null
            )
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch(Exception ex)
            {
                errorCallback?.Invoke(ex);
#if DEBUG
                throw;
#endif
            }
        }

        public static void UpdateIsScrollEnabled(this GoogleMap googleMap, IMap map)
        {
            if(googleMap == null)
                return;

            googleMap.UiSettings.ScrollGesturesEnabled = map.IsScrollEnabled;
        }

        public static void UpdateIsTrafficEnabled(this GoogleMap? googleMap, IMap map)
        {
            if(googleMap == null)
                return;

            googleMap.TrafficEnabled = map.IsTrafficEnabled;
        }

        public static void UpdateIsZoomEnabled(this GoogleMap googleMap, IMap map)
        {
            if(googleMap == null)
                return;

            googleMap.UiSettings.ZoomControlsEnabled = map.IsZoomEnabled;
            googleMap.UiSettings.ZoomGesturesEnabled = map.IsZoomEnabled;
        }

        internal static async Task SetIsShowingUser(this GoogleMap googleMap, IMap map, IMauiContext? mauiContext)
        {
            if(map.IsShowingUser)
            {
                var locationStatus = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

                if(locationStatus == PermissionStatus.Granted)
                {
                    googleMap.MyLocationEnabled = googleMap.UiSettings.MyLocationButtonEnabled = true;
                }
                else
                {
                    var locationResult = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if(locationResult == PermissionStatus.Granted)
                    {
                        googleMap.MyLocationEnabled = googleMap.UiSettings.MyLocationButtonEnabled = true;
                        return;
                    }
                    else
                    {
                        mauiContext?.Services.GetService<ILogger<MapHandler>>()?.LogWarning("Missing location permissions for IsShowingUser");
                        googleMap.MyLocationEnabled = googleMap.UiSettings.MyLocationButtonEnabled = false;
                    }
                }
            }
            else
            {
                googleMap.MyLocationEnabled = googleMap.UiSettings.MyLocationButtonEnabled = false;
            }
        }

        public static PolylineOptions InvokeJointType(this PolylineOptions options, JointType jointType)
        {
            return options.InvokeJointType((int) jointType);
        }

        public static LatLng ToALatLng(this Location location)
        {
            return new LatLng(location.Latitude, location.Longitude);
        }

    }
}
