using MauiMapsOliverV2.IMauiMapElements;
using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.Maps.Handlers
{
    public abstract partial class MapElementHandler<TVirtualView, TPlatformView> : ElementHandler<TVirtualView, TPlatformView>
        where TPlatformView : class, IMauiMapElement
        where TVirtualView : class, IMapElement
    {
		//protected override TPlatformView CreatePlatformElement()
		//{
		//	//if (VirtualView.MapElementId != null)
		//	//{
		//	//	var mapElementId = VirtualView.MapElementId;

		//	//	if (mapElementId is MKPolygon mKPolygon)
		//	//		return new MKPolygonRenderer(mKPolygon);

		//	//	if (mapElementId is MKPolyline line)
		//	//		return new MKPolylineRenderer(line);

		//	//	if (mapElementId is MKCircle circle)
		//	//		return new MKCircleRenderer(circle);
		//	//}

		//	//return new MKOverlayRenderer();
		//}

		//public static void MapStroke(IMapElementHandler handler, IMapStrokeElement mapElement)
		//{
		//	var platformColor = mapElement.Stroke.ToColor()?.ToPlatform();
		//	if (handler.PlatformView is MKPolygonRenderer polygonRenderer)
		//		polygonRenderer.StrokeColor = platformColor;
		//	if (handler.PlatformView is MKPolylineRenderer polylineRenderer)
		//		polylineRenderer.StrokeColor = platformColor;
		//	if (handler.PlatformView is MKCircleRenderer circleRenderer)
		//		circleRenderer.StrokeColor = platformColor;
		//}

		//public static void MapStrokeThickness(IMapElementHandler handler, IMapStrokeElement mapElement)
		//{
		//	if (handler.PlatformView is MKPolygonRenderer polygonRenderer)
		//		polygonRenderer.LineWidth = (nfloat)mapElement.StrokeThickness;
		//	if (handler.PlatformView is MKPolylineRenderer polylineRenderer)
		//		polylineRenderer.LineWidth = (nfloat)mapElement.StrokeThickness;
		//	if (handler.PlatformView is MKCircleRenderer circleRenderer)
		//		circleRenderer.LineWidth = (nfloat)mapElement.StrokeThickness;
		//}

		//public static void MapFill(IMapElementHandler handler, IMapElement mapElement)
		//{
		//	if (mapElement is not IFilledMapElement filledMapElement)
		//		return;

		//	var platformColor = filledMapElement.Fill?.ToColor()?.ToPlatform();

		//	if (handler.PlatformView is MKPolygonRenderer polygonRenderer)
		//		polygonRenderer.FillColor = platformColor;
		//	if (handler.PlatformView is MKCircleRenderer circleRenderer)
		//		circleRenderer.FillColor = platformColor;
		//}
	}
}
