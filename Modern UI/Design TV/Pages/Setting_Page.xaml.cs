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

namespace Design_TV.Pages
{
	/// <summary>
	/// Interaction logic for Setting_Page.xaml
	/// </summary>
	public partial class Setting_Page : UserControl
	{
		private MainWindow window;
		public Setting_Page()
		{
			InitializeComponent();
		}

		private void LoadWindow()
		{
			if(window == null)
			{
				window = Window.GetWindow(App.Current.MainWindow) as MainWindow;
			}
		}

		private void Element_ElementClick(object sender, RoutedEventArgs e)
		{
			LoadWindow();
			window.ExcutePage(AppPages.Network);
        }

		private void Element_ElementClick_1(object sender, RoutedEventArgs e)
		{
			LoadWindow();
			window.ExcutePage(AppPages.Time);
		}

		private void Element_ElementClick_2(object sender, RoutedEventArgs e)
		{
			LoadWindow();
			window.ExcutePage(AppPages.Storage);
		}

		private void Element_ElementClick_3(object sender, RoutedEventArgs e)
		{
			LoadWindow();
			window.ExcutePage(AppPages.About);
		}
    }
}
