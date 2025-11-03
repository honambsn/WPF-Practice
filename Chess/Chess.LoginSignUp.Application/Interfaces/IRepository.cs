using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chess.LoginSignUp.Application.Interfaces
{
    public interface IRepository <T> where T : class
    {
        Task GetByIDAsync (int id);
        Task<IEnumerable<T>> GetAllAsync ();
        Task<IEnumerable> FindAsync(Expression<Func> predicate);
        Task AddAsync (T entity);
        Task UpdateAsync (T entity);
        Task DeleteAsync (int id);
    }
}
