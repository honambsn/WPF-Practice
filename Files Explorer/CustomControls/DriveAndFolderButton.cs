using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace File_Explorer.CustomControls
{
	// Custom button inheriting from RadioButton
	public class DriveAndFolderButton : RadioButton
	{
		// Override the Content property to avoid shadowing warning
		public new object Content
		{
			get { return GetValue(ContentProperty); }
			set { SetValue(ContentProperty, value); }
		}

		// Register the Content DependencyProperty if you need to bind to it
		public static readonly DependencyProperty ContentProperty =
			DependencyProperty.Register("Content", typeof(object), typeof(DriveAndFolderButton), new PropertyMetadata(null));

		// Icon property (PathGeometry)
		public PathGeometry Icon
		{
			get { return (PathGeometry)GetValue(IconProperty); }
			set { SetValue(IconProperty, value); }
		}

		// DependencyProperty for Icon
		public static readonly DependencyProperty IconProperty =
			DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(DriveAndFolderButton));

		// Folder property (Geometry)
		public Geometry Folder
		{
			get { return (Geometry)GetValue(FolderProperty); }
			set { SetValue(FolderProperty, value); }
		}

		// DependencyProperty for Folder
		public static readonly DependencyProperty FolderProperty =
			DependencyProperty.Register("Folder", typeof(Geometry), typeof(DriveAndFolderButton));
	}
}
