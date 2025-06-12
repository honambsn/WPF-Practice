using ChessUI.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessUI.ViewModels
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        public List<WelcomeOption> welcomeOptions { get; } = Enum.GetValues(typeof(WelcomeOption)).Cast<WelcomeOption>().ToList();

        private WelcomeOption selectedOption = WelcomeOption.PlayWithFriend;
        public WelcomeOption SelectedOption
        {
            get => selectedOption;
            set
            {
                if (selectedOption != value)
                {
                    selectedOption = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand PlayCommand { get; }
        public ICommand QuitCommand { get; }

        public event Action<ChooseOptions, WelcomeOption> OptionSelected;

        public WelcomeViewModel()
        {
            PlayCommand = new RelayCommand(_ => OptionSelected?.Invoke(ChooseOptions.Play, selectedOption));
            QuitCommand = new RelayCommand(_ => OptionSelected?.Invoke(ChooseOptions.Exit, selectedOption));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static class WelcomeViewModelHelper
        {
            public static WelcomeViewModel CreateWelcome(Action<ChooseOptions, WelcomeOption> callback)
            {
                var vm = new WelcomeViewModel();
                var view = new Welcome();
                vm.OptionSelected += callback;
                view.DataContext = vm;
                return vm;
            }
        }
    }
}
