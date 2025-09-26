using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.LoginSignUp.Domain.Entities;
using System.ComponentModel;
using Chess.LoginSignUp.Application.Helpers;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Chess.LoginSignUp.Application.Interfaces;



namespace Chess.Login_SignUp.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUserRepository _userRepository;
        //public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public LoginViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            LoginCommand = new RelayCommand(async _ => await LoginAsync(), _ => CanLogin());
        }

        private string _username;
        private string Username
        {
            get => _username;
            set { 
                _username = value; 
                OnPropertyChanged(); 
                (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private string _password;
        private string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
                (LoginCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        private bool CanLogin() =>
            !string.IsNullOrEmpty(Username) && !string.IsNullOrWhiteSpace(Password);

        private async Task LoginAsync()
        {
            var user = await _userRepository.AuthenticateAsync(Username, Password);
            ErrorMessage = user == null ? "Wrong username or password" : $"Welcome {user.Name}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
