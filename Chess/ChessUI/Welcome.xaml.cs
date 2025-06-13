using ChessUI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        public event EventHandler<ModeSelectedEventArgs> ModeSelected;
        public event EventHandler QuitRequested;

        public Welcome()
        {
            InitializeComponent();
            InitalizeModes();
        }

        private void InitalizeModes()
        {
            var botModeItem = new ListBoxItem
            {
                Content = "BOT MODE",
                Width = 120,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Tag = GameMode.BotMode
            };

            var humanModeItem = new ListBoxItem
            {
                Content = "HUMAN MODE",
                Width = 120,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Tag = GameMode.HumanMode
            };

            ModeListBox.Items.Add(botModeItem);
            ModeListBox.Items.Add(humanModeItem);

            Play.IsEnabled = false;
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            QuitRequested?.Invoke(this, EventArgs.Empty);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (ModeListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select game mode first!", "No Mode Selected",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ListBoxItem selectedItem = (ListBoxItem)ModeListBox.SelectedItem;
            GameMode selectedMode = (GameMode)selectedItem.Tag;

            ModeSelected?.Invoke(this, new ModeSelectedEventArgs(selectedMode));
        }
        private void ModeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Play.IsEnabled = ModeListBox.SelectedItem != null;
        }

        public void ResetSelection()
        {
            ModeListBox.SelectedItem = null;
            Play.IsEnabled = false;
        }

    }
}
