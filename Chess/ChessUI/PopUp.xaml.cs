using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChessUI
{
	public partial class PopUp : UserControl
	{
		private DispatcherTimer _timer;
		private int _timeLeft = 10;
        public event EventHandler CountdownFinished;

        public PopUp()
		{
			InitializeComponent();
			InitializeTimer();
		}
		
		private void InitializeTimer()
		{
			_timer = new DispatcherTimer();
			_timer.Interval = TimeSpan.FromSeconds(1);
			_timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			CloseButton.Content = $"Close in {_timeLeft}s";

			_timeLeft--;
			
			if (_timeLeft == 0)
			{
				CloseButton.Content = "Closing....";
			}

			if (_timeLeft < 0)
			{
				_timer.Stop();
				CloseButton.Content = "Closed";
				ClosePopUp();
			}
		}

		private void ClosePopUp()
		{
			if (Parent is Border border)
			{
				border.Visibility = Visibility.Collapsed;
			}
            CountdownFinished?.Invoke(this, EventArgs.Empty);

        }

		public void StartCountdown(int seconds)
		{
			_timeLeft = seconds;
			CloseButton.Content = $"Close in {_timeLeft}s";
			_timer.Start();
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			_timer.Stop();
			ClosePopUp();
		}
	}
}