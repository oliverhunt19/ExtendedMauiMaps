﻿using ExtendedMauiMaps.Core;
using ExtendedMauiMaps.Handlers.MapElement;
using ExtendedMauiMaps.Platforms.iOS.MapElements;

namespace Microsoft.Maui.Maps.Handlers
{
    public partial class PolylineMapElementHandler : StrokeMapElementHandler<IPolylineMapElement, MauiMapPolyline>
    {
        protected override MauiMapPolyline CreateElement()
        {
            throw new NotImplementedException();
        }

        private static void UpdateGeopath(PolylineMapElementHandler handler, IPolylineMapElement element)
        {
            //handler.PlatformView.
        }

    }
}
