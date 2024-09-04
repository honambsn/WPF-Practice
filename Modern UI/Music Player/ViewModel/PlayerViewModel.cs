//using MahApps.Metro.IconPacks;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//namespace Music_Player.ViewModel
//{
//	public class PlayerViewModel : INotifyPropertyChanged
//	{
//		private PackIconMaterialKind _iconKind;

//		public PlayerViewModel()
//		{
//			// Initialize the icon to Play
//			IconKind = PackIconMaterialKind.Play;

//			// Initialize the command
//			ToggleCommand = new RelayCommand(ToggleIcon);
//		}

//		public PackIconMaterialKind IconKind
//		{
//			get => _iconKind;
//			set
//			{
//				if (_iconKind != value)
//				{
//					_iconKind = value;
//					OnPropertyChanged();
//				}
//			}
//		}

//		public ICommand ToggleCommand { get; }

//		private void ToggleIcon()
//		{
//			IconKind = IconKind == PackIconMaterialKind.Play
//				? PackIconMaterialKind.Pause
//				: PackIconMaterialKind.Play;
//		}

//		public event PropertyChangedEventHandler PropertyChanged;

//		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//		{
//			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//		}
//	}
//	public class PlayerViewModel : INotifyPropertyChanged
//	{
//		private PackIconMaterialKind _iconKind;

//		public PlayerViewModel()
//		{
//			// Initialize the icon to Play
//			IconKind = PackIconMaterialKind.Play;

//			// Initialize the command
//			ToggleCommand = new RelayCommand(ToggleIcon);
//		}

//		public PackIconMaterialKind IconKind
//		{
//			get => _iconKind;
//			set
//			{
//				if (_iconKind != value)
//				{
//					_iconKind = value;
//					OnPropertyChanged();
//				}
//			}
//		}

//		public ICommand ToggleCommand { get; }

//		private void ToggleIcon()
//		{
//			IconKind = IconKind == PackIconMaterialKind.Play
//				? PackIconMaterialKind.Pause
//				: PackIconMaterialKind.Play;
//		}

//		public event PropertyChangedEventHandler PropertyChanged;

//		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//		{
//			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//		}
//	}
//}
