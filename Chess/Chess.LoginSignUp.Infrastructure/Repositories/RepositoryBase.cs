using Chess.LoginSignUp.Application.Interfaces;
using Chess.LoginSignUp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        //protected readonly DbSet<T> _dbSet;

        public RepositoryBase(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
            //using (var context = _contextFactory.CreateDbContext())
            //{
            //    _dbSet = context.Set<T>();
            //}
        }

        public async Task AddAsync(T entity)
        {
            using var  context = _contextFactory.CreateDbContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var entity = await context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException($"Cant find entity with the ID {id}");
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        //public async Task<IEnumerable> FindAsync(Expression<Func<T, bool>> predicate)
        //{
        //    using var context = _contextFactory.CreateDbContext();
        //    return await context.Set<T>().Where(predicate).ToListAsync();
        //}

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Set<T>()
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        }

    }
}
