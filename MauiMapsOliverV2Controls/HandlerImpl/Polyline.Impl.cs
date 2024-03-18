using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using MauiMapsOliverV2.Core;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Maps;

namespace Microsoft.Maui.Controls.Maps
{
	public partial class Polyline : IPolylineMapElement
	{


		void NotifyHandler(string action, int index, Location item)
		{
			Handler?.UpdateValue(nameof(Geopath));
		}
	}
}
