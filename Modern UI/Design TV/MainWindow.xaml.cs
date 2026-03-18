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
using System.Windows.Threading;

namespace Design_TV
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public enum AppPages
	{
		About,Setting,Storage,Time,Network
	}
	public partial class MainWindow : Window
	{
		//init all pages in one time
		private Pages.Setting_Page settingPage = new Pages.Setting_Page();
		private Pages.About_Page aboutPage = new Pages.About_Page();
		private Pages.Storage_Page storagePage = new Pages.Storage_Page();
		private Pages.Time_Page timePage = new Pages.Time_Page();
		private Pages.Network_Page networkPage = new Pages.Network_Page();

		private DispatcherTimer _timer;

		public MainWindow()
		{
			InitializeComponent();
			StartClock();
			StartDateUpdate();
		}

		private bool IsMaximzed = false;
		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if(e.ClickCount == 2)
			{
				if (IsMaximzed)
				{
					this.WindowState = WindowState.Normal;
					this.Width = 1280;
					this.Height = 780;

					IsMaximzed = false;
				}
				else
				{
					this.WindowState = WindowState.Maximized;
					IsMaximzed = true;
				}
			}

		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if(e.ChangedButton == MouseButton.Left)
			{
				this.DragMove();
			}
		}

		private void StartClock()
		{
			_timer = new DispatcherTimer();
			_timer.Interval = TimeSpan.FromSeconds(1); // Update every second
			_timer.Tick += Timer_Tick;
			_timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			// Update the TextBlock with the current time
			timeTextBlock.Text = DateTime.Now.ToString("HH:mm");
		}

		private void StartDateUpdate()
		{
			_timer = new DispatcherTimer();
			_timer.Interval = TimeSpan.FromMinutes(1); // Update every minute
			_timer.Tick += Timer_Tick;
			_timer.Start();

			// Initial update
			Date_Tick(null, null);
		}

		private void Date_Tick(object sender, EventArgs e)
		{
			// Update the TextBlocks with the current date and day of the week
			var now = DateTime.Now;
			dateTextBlock.Text = now.ToString("MMMM, dddd"); // Format for "Nov, 17"
			dayTextBlock.Text = now.ToString("dddd"); // Format for "Tuesday"
		}

		private void backButton_Click(object sender, RoutedEventArgs e)
		{
			container.Content = settingPage;
			backButton.Visibility = Visibility.Collapsed;
			titleText.Text = "Settings";
		}

		public void ExcutePage(AppPages page)
		{
			backButton.Visibility = Visibility.Visible;

			switch(page)
			{
				case AppPages.About:
					container.Content = aboutPage;
					titleText.Text = "About Us";
					break;
				case AppPages.Setting:
					container.Content = settingPage;
					titleText.Text = "Settings";
					break;
				case AppPages.Storage:
					container.Content = storagePage;
					titleText.Text = "Storage";
					break;
				case AppPages.Time:
					container.Content = timePage;
					titleText.Text = "Time Settings";
					break;
				case AppPages.Network:
					container.Content = networkPage;
					titleText.Text = "Network Settings";
					break;
				default:
					break;
			}
		}
	}
}
