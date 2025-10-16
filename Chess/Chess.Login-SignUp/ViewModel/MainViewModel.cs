using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Chess.Login_SignUp.Model;
using Chess.Login_SignUp.Repositories;

namespace Chess.Login_SignUp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                userRepository = new UserRepository();
                LoadCurrentUserData();
            }
            
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount = new UserAccountModel()
                {
                    Username = user.Username,
                    DisplayName = $"Welcome {user.Name} {user.LastName} ;)",
                    ProfilePicture = null
                };
            }
            else
            {
                MessageBox.Show("Invalid user");
                Application.Current.Shutdown();
            }
        }
    }
}
