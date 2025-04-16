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
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

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

		public SelectDifferent()
		{
			// Initialize the list of different options
			DifferentOptions = new List<string>
			{
				"Easy",
				"Medium",
				"Hard"
			};
		}

		public List<string> DifferentOptions { get; set; }

		public string SelectedOption { get; set; }

		public void OnOptionSelected(string option)
		{
			if (DifferentOptions.Contains(option))
			{
				SelectedOption = option;
				OnPropertyChanged(nameof(SelectedOption));
			}
			else
			{
				throw new ArgumentException("Invalid option selected.");
			}
		}


		//public string SelectedDiff
		//{
		//	get { return _selectedDiff; }
		//	set
		//	{
		//		if (_selectedDiff != value)
		//		{
		//			_selectedDiff = value;
		//			OnPropertyChanged(nameof(SelectedDiff));

		//			// Xử lý khi giá trị thay đổi
		//			HandleSelectionChange();
		//		}
		//	}
		//}

		//private void HandleSelectionChange()
		//{
		//	// Bạn có thể thêm logic tại đây
		//	// Ví dụ: In ra console hoặc xử lý thêm
		//	System.Diagnostics.Debug.WriteLine($"Đã chọn: {SelectedDiff}");
		//}
	}
}
