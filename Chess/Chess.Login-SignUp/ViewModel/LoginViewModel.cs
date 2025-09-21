using Chess.Login_SignUp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Login_SignUp.Domain.Entities;



namespace Chess.Login_SignUp.ViewModel
{
    public class LoginViewModel
    {
        private readonly IUserRepository _userRepository;
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
    }
}
