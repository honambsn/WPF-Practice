using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ChessUI
{
    /// <summary>
    /// Interaction logic for MoveHistoryWindow.xaml
    /// </summary>
    public partial class MoveHistoryWindow : Window
    {
        public MoveHistoryWindow(ObservableCollection<string> moveHistory)
        {
            InitializeComponent();
            HistoryListBox.ItemsSource = moveHistory;
        }
    }
}
