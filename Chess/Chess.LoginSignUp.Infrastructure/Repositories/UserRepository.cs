using Chess.LoginSignUp.Application.Interfaces;
using Chess.LoginSignUp.Domain.Entities;
using Chess.LoginSignUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<User>? AuthenticateAsync(string username, string password)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(
        //        u => u.Username == username && u.PasswordHash == password);
        //}

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(
                u => u.Username == username && u.PasswordHash == password);
        }


        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
