using Discover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Discover.MVVM.ViewModel
{
	class MainViewModel : ObservableObject
	{
		public RelayCommand HomeViewCommand { get; set; }
		public RelayCommand DiscoveryViewCommand { get; set; }
		public RelayCommand FeaturedViewCommand { get; set; }

		public HomeViewModel HomeVM { get; set; }
		public DiscoveryViewModel DiscoveryVM { get; set; }
		public FeaturedViewModel FeaturedVM { get; set; }
		private object _currentView;

		public ICommand ExitCommand { get; }


		public object CurrentView
		{
			get { return _currentView; }
			set
			{
				_currentView = value;
				OnPropertyChanged();
			}
		}
		public MainViewModel()
		{
			HomeVM = new HomeViewModel();
			DiscoveryVM = new DiscoveryViewModel();
			FeaturedVM = new FeaturedViewModel();

			CurrentView = HomeVM;

			HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });

			DiscoveryViewCommand = new RelayCommand(o => { CurrentView = DiscoveryVM; });

			FeaturedViewCommand = new RelayCommand(o => { CurrentView = FeaturedVM; });

			ExitCommand = new RelayCommand(ExitApp);

		}



		private void ExitApp(object obj)
		{
			System.Windows.Application.Current.Shutdown();

		}

	}
}
