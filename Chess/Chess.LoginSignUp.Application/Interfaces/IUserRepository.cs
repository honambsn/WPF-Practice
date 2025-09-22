using Chess.LoginSignUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
        Task AddAsync(User user);
    }
}
