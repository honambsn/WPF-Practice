using System.Windows;
using System.Windows.Controls;

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : UserControl
    {
        public enum WelcomeOption
        {
            NewGame,
            BotGame,
            Quit
        }
        public event Action<WelcomeOption> OptionSelected;


        public Welcome()
        {
            InitializeComponent();

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(WelcomeOption.Quit);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(WelcomeOption.NewGame);
        }

        private void BotGame_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(WelcomeOption.BotGame);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (ModeListBox.SelectedItem is ListBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();
                if (selectedText == "Bot Mode")
                    OptionSelected?.Invoke(WelcomeOption.BotGame);
                else if (selectedText == "Human Mode")
                    OptionSelected?.Invoke(WelcomeOption.NewGame);
            }
        }
    }
}
