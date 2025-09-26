using Chess.Login_SignUp.ViewModel;
using Chess.LoginSignUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Chess.Login_SignUp.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView(LoginViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Cursor = Cursors.Hand;
                this.DragMove();
            }
            this.Cursor = Cursors.Arrow;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Grid_PreviewMouseDown triggered");
            // Kiểm tra xem người dùng có click ra ngoài TextBox không
            if (!txtUsername.IsMouseOver)
            {
                Debug.WriteLine("Click outside TextBox");
                // Bỏ focus cho TextBox khi click ra ngoài
                Keyboard.ClearFocus();
            }
        }

        private void DraggableArea_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Cursor = Cursors.Hand;
                try
                {
                    this.DragMove();
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            //var options = new 
            //    DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("LoginDemo").Options;
        }
    }
}
