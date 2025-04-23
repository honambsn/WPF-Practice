using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessUI.ViewModels
{
	public class SelectDifferent : INotifyPropertyChanged
	{
		private string _selectedDiff;

		public string SelectedDiff
		{
			get { return _selectedDiff; }
			set
			{
				if (_selectedDiff != value)
				{
					_selectedDiff = value;
					OnPropertyChanged(nameof(SelectedDiff));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
