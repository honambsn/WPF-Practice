﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace File_Explorer.CustomControls
{
	internal class DriveAndFolderButton : RadioButton
	{
		public PathGeometry Icon
		{
			get
			{
				return (PathGeometry)GetValue(IconProperty);
			}
			set
			{
				SetValue(IconProperty, value);
			}
		}

		public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(PathGeometry), typeof(DriveAndFolderButton), new PropertyMetadata(null));
	}
}
