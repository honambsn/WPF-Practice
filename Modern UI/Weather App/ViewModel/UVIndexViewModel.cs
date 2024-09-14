using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Weather_App.ViewModel
{
	internal class UVIndexViewModel : INotifyPropertyChanged
	{
		private double _slider1Value;
		private double _slider2Value;
		private double _slider3Value;
		private double _average;

		public double Slider1Value
		{
			get => _slider1Value;
			set
			{
				if (_slider1Value != value)
				{
					_slider1Value = value;
					OnPropertyChanged();
					UpdateAverage();
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
					OnPropertyChanged();
					UpdateAverage();
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
					OnPropertyChanged();
					UpdateAverage();
				}
			}
		}

		public double Average
		{
			get => _average;
			private set
			{
				if (_average != value)
				{
					_average = value;
					OnPropertyChanged();
				}
			}
		}

		private void UpdateAverage()
		{
			Average = (Slider1Value + Slider2Value + Slider3Value) / 3;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
