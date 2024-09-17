using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App.ViewModel
{
	public class WeatherViewModel : INotifyPropertyChanged
	{
		//private string _iconUrl = "/Images/cloud.png";
		private string _description;
		private string _temperature;
		private string _mainWeather;
		private string _rainAmount;
		private string _cityName;
		private string _countryName;
		private string _iconUrl;

		public string Description
		{
			get { return _description; }
			set
			{
				_description = value;
				OnPropertyChanged("Description");
			}
		}

		public string Temperature
		{
			get { return _temperature; }
			set
			{
				_temperature = value;
				OnPropertyChanged("Temperature");
			}
		}

		public string IconUrl
		{
			get { return _iconUrl; }
			set
			{
				_iconUrl = value;
				OnPropertyChanged("IconUrl");
			}
		}

		public string mainWeather
		{
			get { return _mainWeather; }
			set
			{
				_mainWeather = value;
				OnPropertyChanged("mainWeather");
			}
		}

		public string RainAmount
		{
			get { return _rainAmount; }
			set
			{
				_rainAmount = value;
				OnPropertyChanged("RainAmount");
			}
		}
		public string CityName
		{
			get { return _cityName; }
			set
			{
				_cityName = value;
				OnPropertyChanged("CityName");
			}
		}

		public string CountryName
		{
			get { return _countryName; }
			set
			{
				_countryName = value;
				OnPropertyChanged("CountryName");
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
