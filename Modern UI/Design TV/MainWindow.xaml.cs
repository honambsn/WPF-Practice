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
	public partial class MainWindow : Window
	{
		private DispatcherTimer _timer;

		public MainWindow()
		{
			InitializeComponent();
			StartClock();
			StartDateUpdate();
		}

		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{

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

		}
	}
}
