using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fitness_App.UserControls
{
	/// <summary>
	/// Interaction logic for Map.xaml
	/// </summary>
	public partial class Map : UserControl
	{
		public Map()
		{
			InitializeComponent();
			InitializeMap();
		}

		private void InitializeMap()
		{
			// Set the map provider
			gmap.MapProvider = GMapProviders.GoogleMap; // You can also use other providers

			// Set the position of the map (latitude, longitude)
			gmap.Position = new PointLatLng(10.8231, 106.6297); // hcm, for example

			// Set the zoom level
			gmap.MinZoom = 2;
			gmap.MaxZoom = 18;
			gmap.Zoom = 10;

			// Enable mouse wheel zoom
			gmap.MouseWheelZoomEnabled = true;
			gmap.DragButton = System.Windows.Input.MouseButton.Left;
		}

		public void AddMarker(double lat, double lng)
		{
			GMapMarker marker = new GMapMarker(new PointLatLng(lat, lng))
			{
				Shape = new Ellipse
				{
					Fill = Brushes.Red,
					Stroke = Brushes.Red,
					Width = 10,
					Height = 10,
				}
			};
			gmap.Markers.Add(marker);
		}
	}
}
