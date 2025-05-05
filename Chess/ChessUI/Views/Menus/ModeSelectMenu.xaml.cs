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
	/// Interaction logic for ModeSelectMenu.xaml
	/// </summary>
	public partial class ModeSelectMenu : UserControl
	{
		private readonly Action _onPvPClicked;
		private readonly Action _onPvCClicked;

		public ModeSelectMenu(Action onPvPClicked, Action onPvCClicked)
		{
			InitializeComponent();
			_onPvPClicked = onPvPClicked;
			_onPvCClicked = onPvCClicked;
		}

		private void PvPButton_Click(object sender, RoutedEventArgs e)
		{
			_onPvPClicked?.Invoke();
		}

		private void PvCButton_Click(object sender, RoutedEventArgs e)
		{
			_onPvCClicked?.Invoke();
		}
	}
}
