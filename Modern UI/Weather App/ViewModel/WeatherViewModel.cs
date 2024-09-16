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
		private string _description;
		private string _temperature;
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

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
