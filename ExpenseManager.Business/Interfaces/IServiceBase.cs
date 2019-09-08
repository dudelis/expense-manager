using ExpenseManager.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Business.Interfaces
{
    public interface IServiceBase<T, TRepo>: IServiceBase<T, int, TRepo>
        where T: class, IEntity<int>, new()
        where TRepo : class, IEntityRepository<T>
    {

    }
        public interface IServiceBase<T, TKey, TRepo>
            where T : class, IEntity<TKey>, new()
            where TRepo: class, IEntityRepository<T, TKey>
    {

        T Get(Expression<Func<T, bool>> filter);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        
        T GetById(TKey id);
        Task<T> GetByIdAsync(TKey id);
        bool ItemExists(TKey id);
        Task<bool> ItemExistsAsync(TKey id);
        void Create(T entity);
        ValueTask<EntityEntry<T>> CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}