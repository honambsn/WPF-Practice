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
	internal class SubMenuIconButton : Button
	{
		//public PathGeometry Icon
		//{
		//	get => (PathGeometry)GetValue(IconProperty);
		//	set => SetValue(IconProperty, value);
		//}

		//public static readonly DependencyProperty IconProperty =
		//	DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(SubMenuIconButton));

		// PathGeometry property
		public PathGeometry Icon
		{
			get => (PathGeometry)GetValue(IconProperty);
			set => SetValue(IconProperty, value);
		}

		// Register the Icon dependency property
		public static readonly DependencyProperty IconProperty =
			DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(SubMenuIconButton));

		// Static constructor to associate a default style
		static SubMenuIconButton()
		{
			// Ensures that WPF uses the style defined for SubMenuIconButton
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SubMenuIconButton), new FrameworkPropertyMetadata(typeof(SubMenuIconButton)));
		}

	}
}
