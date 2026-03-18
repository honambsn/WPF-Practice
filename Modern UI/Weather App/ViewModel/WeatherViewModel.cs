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
		private string _localTime;
		private string _localDate;
		private string _localDoWeek;
		private string _windSpeed;
		private string _humidity;
		private string _visibility;
		private string _sunrise;
		private string _sunset;

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

		public string LocalTime
		{
			get { return _localTime; }
			set
			{
				_localTime = value;
				OnPropertyChanged("LocalTime");
			}
		}

		public string LocalDate
		{
			get
			{
				return _localDate;
			}
			set
			{
				_localDate = value;
				OnPropertyChanged("LocalDate");
			}
		}

		public string LocalDoWeek
		{
			get
			{
				return _localDoWeek;
			}
			set
			{
				_localDoWeek = value;
				OnPropertyChanged("LocalDoWeek");
			}
		}
		public string WindSpeed
		{
			get
			{
				return _windSpeed;
			}
			set
			{
				_windSpeed = value;
				OnPropertyChanged("WindSpeed");
			}
		}

		public string Humidity
		{
			get
			{
				return _humidity;
			}
			set
			{
				_humidity = value;
				OnPropertyChanged("Humidity");
			}
		}

		
		public string Visibility
		{
			get
			{
				return _visibility;
			}
			set
			{
				_visibility = value;
				OnPropertyChanged("Visibility");
			}
		}
		
		public string Sunrise
		{
			get
			{
				return _sunrise;
			}
			set
			{
				_sunrise = value;
				OnPropertyChanged("Sunrise");
			}
		}

		public string Sunset
		{
			get
			{
				return _sunset;
			}
			set
			{
				_sunset = value;
				OnPropertyChanged("Sunset");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
