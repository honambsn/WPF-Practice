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

		public string FileExtension
		{
			get { return (string)GetValue(FileExtensionProperty); }
			set { SetValue(FileExtensionProperty, value); }
		}

		public static readonly DependencyProperty FileExtensionProperty =
			DependencyProperty.Register("FileExtension", typeof(string), typeof(PropertiesDialog));

		public string CreatedOn
		{
			get { return (string)GetValue(CreatedOnProperty); }
			set { SetValue(CreatedOnProperty, value); }
		}

		public static readonly DependencyProperty CreatedOnProperty =
			DependencyProperty.Register("CreatedOn", typeof(string), typeof(PropertiesDialog));

		public string DateModified
		{
			get { return (string)GetValue(DateModifiedProperty); }
			set { SetValue(DateModifiedProperty, value); }
		}

		public static readonly DependencyProperty DateModifiedProperty =
			DependencyProperty.Register("DateModified", typeof(string), typeof(PropertiesDialog));

		public string AccessedOn
		{
			get { return (string)GetValue(AccessedOnProperty); }
			set { SetValue(AccessedOnProperty, value); }
		}

		public static readonly DependencyProperty AccessedOnProperty =
			DependencyProperty.Register("AccessedOn", typeof(string), typeof(PropertiesDialog));

		public bool IsReadOnly
		{
			get { return (bool)GetValue(IsReadOnlyProperty); }
			set { SetValue(IsReadOnlyProperty, value); }
		}

		public static readonly DependencyProperty IsReadOnlyProperty =
			DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PropertiesDialog));

		public bool IsHidden
		{
			get { return (bool)GetValue(IsHiddenProperty); }
			set { SetValue(IsHiddenProperty, value); }
		}

		public static readonly DependencyProperty IsHiddenProperty =
			DependencyProperty.Register("IsHidden", typeof(bool), typeof(PropertiesDialog));

		public bool IsSystem
		{
			get { return (bool)GetValue(IsSystemProperty); }
			set { SetValue(IsSystemProperty, value); }
		}
		public static readonly DependencyProperty IsSystemProperty =
			DependencyProperty.Register("IsSystem", typeof(bool), typeof(PropertiesDialog));	

		public string FullPath { get; internal set; }

		public static readonly DependencyProperty IsFullPathProperty =
			DependencyProperty.Register("IsSystem", typeof(bool), typeof(PropertiesDialog));

		public string FileSize { get; internal set; }

		public static readonly DependencyProperty IsFileSizeroperty =
			DependencyProperty.Register("IsSystem", typeof(bool), typeof(PropertiesDialog));


	}
}
