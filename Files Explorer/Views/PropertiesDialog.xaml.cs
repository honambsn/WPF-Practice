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
using System.Windows.Shapes;

namespace Files_Explorer.Views
{
	/// <summary>
	/// Interaction logic for PropertiesDialog.xaml
	/// </summary>
	public partial class PropertiesDialog : Window
	{
		public PropertiesDialog()
		{
			InitializeComponent();
		}

		public PathGeometry Icon
		{
			get { return (PathGeometry)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		public static readonly DependencyProperty IconProperty =
			DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(PropertiesDialog));

		public string FileName
		{
			get { return (string)GetValue(FileNameProperty); }
			set { SetValue(FileNameProperty, value); }
		}

		public static readonly DependencyProperty FileNameProperty =
			DependencyProperty.Register("FileName", typeof(string), typeof(PropertiesDialog));

	}
}
