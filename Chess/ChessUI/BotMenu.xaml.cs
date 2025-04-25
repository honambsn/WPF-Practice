using ChessAI;
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
		public event Action<BotOptions> OptionSelectedd;
		public event Action<BotOptions, BotDifficulty> OptionSelected;

		public BotMenu()
		{
			InitializeComponent();

			var viewModel = new BotMenuViewModel();
			DataContext = viewModel;

			viewModel.OptionSelected += (option, difficulty) =>
			{
				OptionSelected?.Invoke(option, difficulty);
			};
		}

		private void Play_Click(object sender, RoutedEventArgs e)
		{

			//Console.WriteLine("PLAY Button Clicked!");
			//OptionSelected?.Invoke(BotOptions.Play);

			//var viewModel = DataContext as BotMenuViewModel;
			//if (viewModel != null)
			//	viewModel.StartGameCommand.Execute(null);
			//OptionSelected?.Invoke(BotOptions.Play);
			if (string.IsNullOrEmpty(_selectedDiff))
			{
				MessageBox.Show("Please select a difficulty level.");
				return;
			}

			if (Enum.TryParse(_selectedDiff, out BotDifficulty difficulty))
			{
				OptionSelected?.Invoke(BotOptions.Play, difficulty);
			}
			else
			{
				MessageBox.Show("Invalid difficulty level selected.");
			}
		}


		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			OptionSelectedd?.Invoke(BotOptions.Exit);
		}

		private string _selectedDiff;

		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string selectedDiff = (sender as ListBox).SelectedItem as string;
			if (selectedDiff != null)
			{
				_selectedDiff = selectedDiff;
				MessageBox.Show($"Selected difficulty: {_selectedDiff}");
			}
			else
			{
				MessageBox.Show("No difficulty selected.");
			}
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
