using ChessAI;
using ChessLogic;
using ChessUI.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;

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
		public List<BotDifficulty> Difficulties { get; } = new Enum.GetValues(typeof(BotDifficulty)).Cast<BotDifficulty>()
																							  .ToList();

		private BotDifficulty selectedDiff = BotDifficulty.Easy;
		public BotDifficulty SelectedDiff
		{
			get => selectedDiff;
			set
			{
				selectedDiff = value;
				OnPropertyChanged(nameof(selectedDiff));
			}
		}

		public ICommand PlayCommand { get; }
		public ICommand ExitCommand { get; }

		public event Action<BotOptions, BotDifficulty> OptionSelected;

		public BotMenuViewModel()
		{
			PlayCommand = new RelayCommand(_ => OptionSelected?.Invoke(BotOptions.Play, SelectedDiff));
			ExitCommand = new RelayCommand(_ => OptionSelected?.Invoke(BotOptions.Exit, SelectedDiff));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		
		public static class BotMenuViewModelHelper
		{
			public static BotMenu CreateBotMenu(Action<BotOptions, BotDifficulty> callback)
			{
				var vm = new BotMenuViewModel();
				var view = new BotMenu();
				vm.OptionSelected += callback;
				view.dataContext = vm;
				return view;
			}
		}
	}
}
