using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessUI.Views.Menus
{
	/// <summary>
	/// Interaction logic for PlayExitMenu.xaml
	/// </summary>
	public partial class PlayExitMenu : UserControl
	{
		private Action _onPlayClicked;
		private Action _onExitClicked;

		public PlayExitMenu(Action onPlayClicked, Action onExitClicked)
		{
			InitializeComponent();
			_onPlayClicked = onPlayClicked;
			_onExitClicked = onExitClicked;
		}

		private void Play_Click(object sender, RoutedEventArgs e)
		{
			_onPlayClicked?.Invoke();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			_onExitClicked?.Invoke();
		}
	}
}
