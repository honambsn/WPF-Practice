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

namespace Design_TV.UserControls
{
	/// <summary>
	/// Interaction logic for TimeSetting.xaml
	/// </summary>
	public partial class TimeSetting : UserControl
	{
		public TimeSetting()
		{
			InitializeComponent();
		}
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(TimeSetting));


		public bool HasToggle
		{
			get { return (bool)GetValue(HasToggleProperty); }
			set { SetValue(HasToggleProperty, value); }
		}
		public static readonly DependencyProperty HasToggleProperty = DependencyProperty.Register("HasToggle", typeof(bool), typeof(TimeSetting));


		public bool IsChecked
		{
			get { return (bool)GetValue(IsCheckedProperty); }
			set { SetValue(IsCheckedProperty, value); }
		}
		public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(bool), typeof(TimeSetting));


		public bool HasText
		{
			get { return (bool)GetValue(HasTextProperty); }
			set { SetValue(HasTextProperty, value); }
		}
		public static readonly DependencyProperty HasTextProperty = DependencyProperty.Register("HasText", typeof(bool), typeof(TimeSetting));


		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TimeSetting));

	}
}
