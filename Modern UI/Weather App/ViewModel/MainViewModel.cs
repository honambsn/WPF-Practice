using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public WeatherViewModel WeatherViewModel { get; set; }
		public UVIndexViewModel UVIndexViewModel { get; set; }


		public MainViewModel()
		{
			WeatherViewModel = new WeatherViewModel();
			UVIndexViewModel = new UVIndexViewModel();
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
