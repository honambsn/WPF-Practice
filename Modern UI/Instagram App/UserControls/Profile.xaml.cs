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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Instagram_App.UserControls
{
	/// <summary>
	/// Interaction logic for Profile.xaml
	/// </summary>
	public partial class Profile : UserControl
	{
		public Profile()
		{
			InitializeComponent();
		}
		public int PaddingNum
		{
			get { return (int)GetValue(PaddingNumProperty); }
			set { SetValue(PaddingNumProperty, value); }
		}

		public static readonly DependencyProperty PaddingNumProperty = DependencyProperty.Register("PaddingNum", typeof(int), typeof(Profile));


		public int Size
		{
			get { return (int)GetValue(SizeProperty); }
			set { SetValue(SizeProperty, value); }
		}

		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(int), typeof(Profile));


		public ImageSource Source
		{
			get { return (ImageSource)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}

		public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(Profile));
	}
}
