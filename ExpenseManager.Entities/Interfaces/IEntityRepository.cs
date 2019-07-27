using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpenseManager.Entities.Interfaces
{
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        bool ItemExists(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);        
    }
    public interface IEntityRepository<T, TKey> where T : class, IEntity<TKey>, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        bool ItemExists(Expression<Func<T, bool>> filter);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
