using ChessUI.ViewModels;
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
			DataContext = new BotMenuViewModel();
		}

		private void Play_Click(object sender, RoutedEventArgs e)
		{

			//Console.WriteLine("PLAY Button Clicked!");
			//OptionSelected?.Invoke(BotOptions.Play);

			var viewModel = DataContext as BotMenuViewModel;
			if (viewModel != null)
				viewModel.StartGameCommand.Execute(null);
		}


		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(BotOptions.Exit);
		}

		private string _selectedDiff;

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string selectedDiff = (sender as ListBox).SelectedItem as string;
			MessageBox.Show($"Selected difficulty: {selectedDiff}");
		}
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
