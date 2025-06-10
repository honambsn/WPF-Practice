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


    }
}
