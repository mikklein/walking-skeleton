using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WalkingSkeleton.API.DAL.core
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        void Delete(int id);

        void Update(T entity);
        void Update(T t, object key);
        void UpdateProperty(object key, string property, object value);

        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(int Id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    }
}