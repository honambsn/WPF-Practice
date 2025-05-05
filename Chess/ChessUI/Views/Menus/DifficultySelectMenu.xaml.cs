using ChessAI;
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
	/// Interaction logic for DifficultySelectMenu.xaml
	/// </summary>
	public partial class DifficultySelectMenu : UserControl
	{
		private readonly Action<BotDifficulty> _onDifficultySelected;
		
		public DifficultySelectMenu(Action<BotDifficulty> onDifficultySelected)
		{
			InitializeComponent();
			_onDifficultySelected = onDifficultySelected;
		}

		private void Easy_Click(object sender, RoutedEventArgs e)
		{
			_onDifficultySelected?.Invoke(BotDifficulty.Easy);
		}

		private void Medium_Click(object sender, RoutedEventArgs e)
		{
			_onDifficultySelected?.Invoke(BotDifficulty.Medium);
		}

		private void Hard_Click(object sender, RoutedEventArgs e)
		{
			_onDifficultySelected?.Invoke(BotDifficulty.Hard);
		}


	}
}
