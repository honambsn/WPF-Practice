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

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for GameMode.xaml
    /// </summary>
    #region ver 1
    //public partial class GameMode : UserControl
    //{
    //    private MainWindow _mainWindow;
    //    public GameMode()
    //    {
    //        InitializeComponent();
    //        //LoadModeComponent();
    //    }

    //    public GameMode(MainWindow mainWindow) : this()
    //    {
    //        _mainWindow = mainWindow;
    //    }

    //    public void SetMainWindow(MainWindow mainWindow)
    //    {
    //        _mainWindow = mainWindow;
    //    }

    //    private void Play_Click(object sender, RoutedEventArgs e)
    //    {
    //        try
    //        {
    //            // Debug: Check selection
    //            MessageBox.Show($"Selected Item: {ModeListBox.SelectedItem?.ToString() ?? "NULL"}", "Debug Info");

    //            if (ModeListBox.SelectedItem == null)
    //            {
    //                MessageBox.Show("Please select a game mode!", "No Mode Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
    //                return;
    //            }

    //            string selectedMode = ModeListBox.SelectedItem.ToString();
    //            MessageBox.Show($"Selected Mode: {selectedMode}", "Debug Mode");

    //            // Tìm MainWindow parent
    //            //MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

    //            // Use stored reference instead of Window.GetWindow()
    //            if (_mainWindow == null)
    //            {
    //                MessageBox.Show("MainWindow reference not set!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    //                return;
    //            }

    //            _mainWindow.CloseGameMode();

    //            if (selectedMode == "Bot Mode")
    //            {
    //                _mainWindow.BotMode();
    //            }
    //            else if (selectedMode == "Human Mode")
    //            {
    //                _mainWindow.HumanMode();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
    //        }
    //    }

    //    private void Quit_Click(object sender, RoutedEventArgs e)
    //    {
    //        Application.Current.Shutdown();
    //    }

    //    private void LoadModeComponent()
    //    {
    //        //ModeListBox.Width = 200;
    //        ModeListBox.Items.Clear();

    //        ModeListBox.Items.Add("BOT MODE");
    //        ModeListBox.Items.Add("HUMAN MODE");

    //        //ModeListBox.Items.Add("RESUME GAME");
    //        //ModeListBox.Items.Add("PLAY WITH BOT");
    //        //ModeListBox.Items.Add("PLAY WITH FRIEND");
    //        //ModeListBox.Items.Add("PLAY ONLINE");
    //        //ModeListBox.Items.Add("SETTINGS");

    //        ModeListBox.SelectedIndex = 0;

    //    }

    //    private void ModeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //    {

    //    }

    //}

    #endregion
    public partial class GameMode : UserControl
    {
        public event EventHandler BotModeRequested;
        public event EventHandler HumanModeRequested;
        public GameMode()
        {
            InitializeComponent();
            //LoadModeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Debug: Check selection
                //MessageBox.Show($"Play click - Selected Item: {ModeListBox.SelectedItem?.ToString() ?? "NULL"}", "Debug Info");
                //Console.WriteLine($"Play click - Selected Item: {ModeListBox.SelectedItem?.ToString() ?? "NULL"}");

                if (ModeListBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a game mode!", "No Mode Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (ModeListBox.SelectedItem is ListBoxItem listItem)
                {
                    MessageBox.Show("Selected Item is a ListBoxItem", "Debug Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                string selectedMode = (ModeListBox.SelectedItem as ListBoxItem)?.Content.ToString().Trim();

                //MessageBox.Show($"Selected Mode: {selectedMode}", "Debug Mode", MessageBoxButton.OK, MessageBoxImage.Information);

                if (selectedMode != null)
                {
                    MessageBox.Show($"Check the Mode: {selectedMode}", "Debug Mode");
                }
                else
                {
                    MessageBox.Show("No mode selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // Tìm MainWindow parent
                //MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

                // Use stored reference instead of Window.GetWindow()
                if (string.Equals(selectedMode, "Bot Mode", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Bot Mode selected from play click", "Debug Info", MessageBoxButton.OK);
                    BotModeRequested?.Invoke(this, EventArgs.Empty);
                }
                else if (string.Equals(selectedMode, "Human Mode", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Human Mode selected from play click", "Debug Info", MessageBoxButton.OK);
                    HumanModeRequested?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Unknown mode selected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoadModeComponent()
        {
            //ModeListBox.Width = 200;
            ModeListBox.Items.Clear();

            ModeListBox.Items.Add("BOT MODE");
            ModeListBox.Items.Add("HUMAN MODE");

            //ModeListBox.Items.Add("RESUME GAME");
            //ModeListBox.Items.Add("PLAY WITH BOT");
            //ModeListBox.Items.Add("PLAY WITH FRIEND");
            //ModeListBox.Items.Add("PLAY ONLINE");
            //ModeListBox.Items.Add("SETTINGS");

            ModeListBox.SelectedIndex = 0;

        }

        private void ModeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show($"Selected Mode Changed: {ModeListBox.SelectedItem?.ToString() ?? "NULL"}", "Debug Info");
        }

    }
}
