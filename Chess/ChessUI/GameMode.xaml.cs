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
    public partial class GameMode : UserControl
    {
        public GameMode()
        {
            InitializeComponent();
            LoadModeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (ModeListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select game mode first!", "No Mode Selected",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedMode = ModeListBox.SelectedItem.ToString();

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null)
            {
                switch (selectedMode)
                {
                    case "BOT MODE":
                        mainWindow.BotMode();
                        break;
                    case "HUMAN MODE":
                        mainWindow.HumanMode();
                        break;
                    case "RESUME GAME":
                        //mainWindow.ResumeGame();
                        break;
                    case "PLAY WITH BOT":
                        //mainWindow.PlayWithBot();
                        break;
                    case "PLAY WITH FRIEND":
                        //mainWindow.PlayWithFriend();
                        break;
                    case "PLAY ONLINE":
                        //mainWindow.PlayOnline();
                        break;
                    case "SETTINGS":
                    //    mainWindow.OpenSettings();
                        break;
                    default:
                        MessageBox.Show("Invalid game mode selected.", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }

            //if (mainWindow != null)
            //{
            //    if (selectedMode == "BOT MODE")
            //    {
            //        mainWindow.BotMode();
            //    }
            //    else if (selectedMode == "HUMAN MODE")
            //    {
            //        mainWindow.HumanMode();
            //    }
            //}
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

        }
    }
}
