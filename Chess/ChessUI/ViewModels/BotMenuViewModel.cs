using ChessAI;
using ChessLogic;
using ChessUI.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ChessUI.ViewModels
{
	//old version
	//public class BotMenuViewModel : INotifyPropertyChanged
	//{
	//	private string _selectedDiff;
	//	public string SelectedDiff
	//	{
	//		get => _selectedDiff;
	//		set
	//		{
	//			if (_selectedDiff != value)
	//			{
	//				_selectedDiff = value;
	//				OnPropertyChanged();
	//				OnPropertyChanged(nameof(IsDifficultySelected));
	//			}
	//		}
	//	}

	//	public bool IsDifficultySelected => !string.IsNullOrEmpty(SelectedDiff);

	//	public ICommand PlayCommand { get; }
	//	public ICommand ExitCommand { get; }

	//	public event Action<BotDifficulty> StartBotGameRequested;
	//	public event Action ExitRequested;

	//	public BotMenuViewModel()
	//	{
	//		PlayCommand = new RelayCommand(_ => StartGame(), _ => IsDifficultySelected);
	//		ExitCommand = new RelayCommand(_ => Exit());
	//	}

	//	private void StartGame()
	//	{
	//		if (Enum.TryParse(SelectedDiff, out BotDifficulty diff))
	//		{
	//			StartBotGameRequested?.Invoke(diff);
	//		}
	//	}

	//	private void Exit()
	//	{
	//		ExitRequested?.Invoke();
	//	}

	//	public event PropertyChangedEventHandler PropertyChanged;
	//	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	//	{
	//		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	//	}
	//}

	public class BotMenuViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public BotDifficulty SelectedDiff { get; set; }

		public ICommand StartGameCommand { get; }

		public BotMenuViewModel()
		{
			StartGameCommand = new RelayCommand(PlayGame);
		}

		private void PlayGame()
		{
			// Gửi tín hiệu sang UI chính để bắt đầu chơi với bot
			OnStartBotGameRequested?.Invoke(this, SelectedDiff);
		}

		public event EventHandler<BotDifficulty> OnStartBotGameRequested;
	}
}
