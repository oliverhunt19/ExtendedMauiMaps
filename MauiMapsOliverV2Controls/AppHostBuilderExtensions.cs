using Microsoft.Maui.LifecycleEvents;
using ExtendedMauiMaps.Handlers.Map;
using ExtendedMauiMaps.Handlers.MapPin;
using ExtendedMauiMaps.Handlers.MapElement.Circle;
using ExtendedMauiMaps.Handlers.MapElement.Polygon;
using ExtendedMauiMaps.Handlers.MapElement.Polyline;






#if ANDROID
using Android.Gms.Common;
using Android.Gms.Maps;
#endif

namespace ExtendedMauiMapsControl
{
    /// <summary>
    /// This class contains the Map's <see cref="MauiAppBuilder"/> extensions.
    /// </summary>
    public static partial class AppHostBuilderExtensions
    {
        /// <summary>
        /// Configures <see cref="MauiAppBuilder"/> to add support for the <see cref="Map"/> control.
        /// </summary>
        /// <param name="builder">The <see cref="MauiAppBuilder"/> to configure.</param>
        /// <returns>The configured <see cref="MauiAppBuilder"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown on Windows because the maps control currently is not implemented for Windows.</exception>
        public static MauiAppBuilder UseMauiMaps(this MauiAppBuilder builder)
        {
            builder
                .ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddMauiMaps();
                })
                .ConfigureLifecycleEvents(events =>
                {
#if __ANDROID__
                    // Log everything in this one
                    events.AddAndroid(android => android
                        .OnCreate((a, b) =>
                        {

                            MapHandler.Bundle = b;
                            if(GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(a) == ConnectionResult.Success)
                            {
                                try
                                {
                                    MapsInitializer.Initialize(a);
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine("Google Play Services Not Found");
                                    Console.WriteLine("Exception: {0}", e);
                                }
                            }
                        }));
#endif
                });

            return builder;
        }

        /// <summary>
        /// Registers the .NET MAUI Maps handlers that are needed to render the map control.
        /// </summary>
        /// <param name="handlersCollection">An instance of <see cref="IMauiHandlersCollection"/> on which to register the map handlers.</param>
        /// <returns>The provided <see cref="IMauiHandlersCollection"/> object with the registered map handlers for subsequent registration calls.</returns>
        /// <exception cref="NotImplementedException">Thrown on Windows because the maps control currently is not implemented for Windows.</exception>
        public static IMauiHandlersCollection AddMauiMaps(this IMauiHandlersCollection handlersCollection)
        {
#if __ANDROID__ || __IOS__
            handlersCollection.AddHandler<Map, MapHandler>();
            handlersCollection.AddHandler<Pin, MapPinHandler>();
            handlersCollection.AddHandler<Circle, CircleMapElementHandler>();
            handlersCollection.AddHandler<Polygon, PolygonMapElementHandler>();
            handlersCollection.AddHandler<Polyline, PolylineMapElementHandler>();
#endif

#if WINDOWS
            throw new NotImplementedException(".NET MAUI Maps is currently not implemented for Windows. For more information, please see: https://aka.ms/maui-maps-no-windows");
#else
            return handlersCollection;
#endif
        }
    }
}
