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
        public event Action<ChooseOptions> OptionSelectedd;
        public event Action<ChooseOptions, WelcomeOption> OptionSelected;

        public Welcome()
        {
            InitializeComponent();

            var viewModel = new WelcomeViewModel();
            DataContext = viewModel;
            viewModel.OptionSelected += (option, welcomeOption) =>
            {
                OptionSelected?.Invoke(option, welcomeOption);
            };

        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            OptionSelectedd?.Invoke(ChooseOptions.Quit);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedOption))
            {
                MessageBox.Show("Please select an option.");
                return;
            }
            if (Enum.TryParse(_selectedOption, out WelcomeOption option))
            {
                OptionSelected?.Invoke(ChooseOptions.Play, option);
            }
            else
            {
                MessageBox.Show("Invalid option selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string _selectedOption;

        private void ModeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedOption = (sender as ListBox).SelectedItem as string;
            if (selectedOption != null)
            {
                _selectedOption = selectedOption;
                MessageBox.Show($"You selected: {_selectedOption}", "Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No option selected.", "Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
