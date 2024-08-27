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

namespace Flat_Sales_Dashboard.UserControls
{
	/// <summary>
	/// Interaction logic for InfoCard.xaml
	/// </summary>
	public partial class InfoCard : UserControl
	{
		public InfoCard()
		{
			InitializeComponent();
		}

		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(InfoCard));


		public string SubTitle
		{
			get { return (string)GetValue(SubTitleProperty); }
			set { SetValue(SubTitleProperty, value); }
		}

		public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register("SubTitle", typeof(string), typeof(InfoCard));


		public int Amount
		{
			get { return (int)GetValue(AmountProperty); }
			set { SetValue(AmountProperty, value); }
		}

		public static readonly DependencyProperty AmountProperty = DependencyProperty.Register("Amount", typeof(int), typeof(InfoCard));


		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(InfoCard));

	}
}
