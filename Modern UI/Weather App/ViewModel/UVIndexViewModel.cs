using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App.ViewModel
{
	public class UVIndexViewModel : INotifyPropertyChanged
	{
		private double _slider1Value;
		private double _slider2Value;
		private double _slider3Value;

		public event PropertyChangedEventHandler PropertyChanged;

		public double Slider1Value
		{
			get => _slider1Value;
			set
			{
				if (_slider1Value != value)
				{
					_slider1Value = value;
					OnPropertyChanged(nameof(Slider1Value));
					OnPropertyChanged(nameof(Average));
				}
			}
		}

		public double Slider2Value
		{
			get => _slider2Value;
			set
			{
				if (_slider2Value != value)
				{
					_slider2Value = value;
					OnPropertyChanged(nameof(Slider2Value));
					OnPropertyChanged(nameof(Average));
				}
			}
		}

		public double Slider3Value
		{
			get => _slider3Value;
			set
			{
				if (_slider3Value != value)
				{
					_slider3Value = value;
					OnPropertyChanged(nameof(Slider3Value));
					OnPropertyChanged(nameof(Average));
				}
			}
		}

		public double Average => (Slider1Value + Slider2Value + Slider3Value) / 3;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}	
	}
}