﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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
			OptionSelected?.Invoke(BotOptions.Play);
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			OptionSelected?.Invoke(BotOptions.Exit);
		}
	}
}
