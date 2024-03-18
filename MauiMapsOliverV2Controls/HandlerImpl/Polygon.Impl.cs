using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MauiMapsOliverV2.Core;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Maps;

namespace Microsoft.Maui.Controls.Maps
{
	public partial class Polygon : IPolygonMapElement
    {
		/// <inheritdoc cref="IFilledMapElement.Fill"/>
		public Paint? Fill => FillColor?.AsPaint();


        

  //      /// <summary>
  //      /// Adds a location to this polygon.
  //      /// </summary>
  //      /// <param name="item">The location to add.</param>
  //      public void Add(Location item)
		//{
		//	var index = Geopath.Count;
		//	Geopath.Add(item);
		//	NotifyHandler(nameof(Add), index, item);
		//}


		void NotifyHandler(string action, int index, Location item)
		{
			Handler?.UpdateValue(nameof(Geopath));
		}
	}
}
