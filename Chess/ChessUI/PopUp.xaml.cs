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
	/// <summary>
	/// Interaction logic for PopUp.xaml
	/// </summary>
	public partial class PopUp : UserControl
	{
		private DispatcherTimer countdownTimer;
		private int countdownSeconds = 10;  // Khởi tạo đếm ngược với 10 giây
		private bool isCountdownActive = false;

		public PopUp()
		{
			InitializeComponent();

			// Khởi tạo Timer đếm ngược
			countdownTimer = new DispatcherTimer
			{
				Interval = TimeSpan.FromSeconds(1)  // Đặt khoảng thời gian đếm ngược là 1 giây
			};

			countdownTimer.Tick += CountdownTimer_Tick;  // Gắn sự kiện Tick
		}

		// Hàm bắt đầu đếm ngược
		public void StartCountdown(int initialSeconds = 10)
		{
			countdownSeconds = initialSeconds;  // Thiết lập thời gian đếm ngược ban đầu (ví dụ: 10 giây)
			isCountdownActive = true;
			countdownTimer.Start();  // Bắt đầu đếm ngược
			UpdateCloseButtonText();  // Cập nhật lại nội dung của nút Close với thời gian ban đầu
		}

		// Sự kiện được gọi mỗi giây (Tick) để giảm số giây và cập nhật lại nội dung của nút
		private void CountdownTimer_Tick(object sender, EventArgs e)
		{
			if (countdownSeconds > 0)
			{
				countdownSeconds--;  // Giảm số giây mỗi lần tick
				UpdateCloseButtonText();  // Cập nhật lại nội dung của nút Close
			}
			else
			{
				countdownTimer.Stop();  // Dừng timer khi đếm ngược hết thời gian
				ClosePopup();  // Đóng popup tự động khi hết thời gian
			}
		}

		// Cập nhật nội dung nút Close với thời gian còn lại
		private void UpdateCloseButtonText()
		{
			CloseButton.Content = $"Đóng trong {countdownSeconds}s";  // Cập nhật thời gian còn lại
		}

		// Hàm xử lý sự kiện khi người dùng nhấn nút Close
		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			countdownTimer.Stop();  // Dừng đếm ngược khi nhấn Close
			ClosePopup();  // Đóng popup
		}

		// Hàm đóng popup
		private void ClosePopup()
		{
			this.Visibility = Visibility.Collapsed;  // Ẩn popup
			this.Opacity = 1;  // Khôi phục opacity nếu có thay đổi trong bất kỳ hiệu ứng nào
		}
	}

}