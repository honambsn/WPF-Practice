using Chess.LoginSignUp.Application.Interfaces;
using Chess.LoginSignUp.Domain.Entities;
using Chess.LoginSignUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Chess.LoginSignUp.Application.Helpers;

namespace Chess.LoginSignUp.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public UserRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //public async Task<User>? AuthenticateAsync(string username, string password)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(
        //        u => u.Username == username && u.PasswordHash == password);
        //}

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            //return await _context.Users.FirstOrDefaultAsync(
            //    u => u.Username == username && u.PasswordHash == password);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return null;

            //byte[] storedSalt = user.PasswordSalt;
            //byte[] storedHash = user.PasswordHash;

            //using (var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100_00, HashAlgorithmName.SHA256))
            //{
            //    byte[] computeHash = pbkdf2.GetBytes(storedHash.Length);

            //    return computeHash.SequenceEqual(storedHash) ? user : null;
            //}

            if (PasswordHasher.VerifyPassword(user.PasswordHash, password))
                return user;
            else
                return null;
            
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

        public async Task<IEnumerable<User>> GetUserWithRoleAsync()
        {
            return await _context.Users.Include(u => u.Role).ToListAsync();
        }

        //public Task<User?> AuthenticateAsync(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<User?> GetByUsernameAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task ExistsAsync(string username, string email)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Edit(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetByAll()
        {
            throw new NotImplementedException();
        }

        public Task GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable> FindAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<User> IRepository<User>.GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetPagedAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
