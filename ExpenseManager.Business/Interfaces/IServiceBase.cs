using ExpenseManager.Entities.Interfaces;
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
        List<T> GetAll();
        T GetById(TKey id);
        bool ItemExists(TKey id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}