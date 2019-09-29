using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IEntityRepository<T> : IEntityRepository<T, int> where T : class, IEntity<int>, new()
    {

    }

    public interface IEntityRepository<T, TKey> where T : class, IEntity<TKey>, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        bool ItemExists(Expression<Func<T, bool>> filter);
        Task<bool> ItemExistsAsync(Expression<Func<T, bool>> filter);
        void Create(T entity);
        ValueTask<EntityEntry<T>> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void Save();
        Task SaveAsync();
    }
}
