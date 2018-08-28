using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WalkingSkeleton.API.DAL.core
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        private DbSet<T> DbSet {
            get { return _context.Set<T>(); }
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(int Id)
        {
            DbSet.Remove(DbSet.Find(Id));
            _context.SaveChanges();
        }

        public async Task<int> CountAsync()
        {
            return await DbSet.CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).CountAsync();
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T t, object key)  
        {  
            T exist = DbSet.Find(key);  
            if (exist != null) {   
                _context.Entry(exist).CurrentValues.SetValues(t);  
                _context.SaveChanges();  
            } 
        }

        public virtual void UpdateProperty(object key, string property, object value)
        {  
            T exist = DbSet.Find(key);
            var prop = exist.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if(prop != null && prop.CanWrite){
                prop.SetValue(exist, value, null);
                _context.SaveChanges();
            }
        }

        public async Task<T> GetAsync(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)  
        {  
            return await DbSet.SingleOrDefaultAsync(predicate);  
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }
    }
}