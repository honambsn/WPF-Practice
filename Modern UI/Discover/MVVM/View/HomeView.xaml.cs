﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Discover.MVVM.View
{
	/// <summary>
	/// Interaction logic for HomeView.xaml
	/// </summary>
	public partial class HomeView : UserControl
	{
		public HomeView()
		{
			InitializeComponent();
		}

		private void Border_MouseEnter(object sender, MouseEventArgs e)
		{
			var storyboard = (Storyboard)FindResource("HoverEnterStoryboard");
			storyboard.Begin();
		}

		private void Border_MouseLeave(object sender, MouseEventArgs e)
		{
			var storyboard = (Storyboard)FindResource("HoverLeaveStoryboard");
			storyboard.Begin();
		}
    }
}
