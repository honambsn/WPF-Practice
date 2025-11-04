using Chess.LoginSignUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Chess.LoginSignUp.Application.Interfaces;
using System.Collections;

namespace Chess.LoginSignUp.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> AuthenticateAsync(string username, string password);
        Task AddAsync(User user);
        Task<User?> GetUserAsync(string username);

        Task<IEnumerable<User>> GetUserWithRoleAsync();

        Task GetByUsernameAsync(string username);
        Task GetByEmailAsync(string email);
        Task ExistsAsync(string username, string email);
        //Task AuthenticateAsync(string username, string password);

        // Sync methods (giữ tương thích)
        bool AuthenticateUser(NetworkCredential credential);
        void Add(User user);
        void Edit(User user);
        void Remove(int id);
        User GetByID(int id);
        User GetByUsername(string username);
        IEnumerable GetByAll();
    }
}
