using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
	/// <summary>
	/// Interaction logic for BotMenu.xaml
	/// </summary>
	public partial class BotMenu : UserControl
	{
		public event Action<BotOptions> OptionSelected;
		public BotMenu()
		{
			InitializeComponent();
		}

		private void Play_Click(object sender, RoutedEventArgs e)
		{
			
			Console.WriteLine("PLAY Button Clicked!");
			OptionSelected?.Invoke(BotOptions.Play);
		}


		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(BotOptions.Exit);
		}

		private string _selectedDiff;
		//public string SelectedDiff
		//{
		//	get { return _selectedDiff; }
		//	set
		//	{
		//		_selectedDiff = value;
		//		OnPropertyChanged(nameof(SelectedDiff));
		//	}
		//}
	}

}
