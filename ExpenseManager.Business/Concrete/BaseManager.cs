using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.Business.Concrete
{
    public class BaseManager<T, TRepository>: BaseManager<T, int, TRepository>
        where T : class, IEntity, new()
        where TRepository : class, IEntityRepository<T>
    {
        public BaseManager(TRepository repository) : base(repository) { }
    }
    public class BaseManager<T, TKey, TRepository> : IServiceBase<T, TKey, TRepository>
        where T : class, IEntity<TKey>, new()
        where TRepository : class, IEntityRepository<T, TKey>
    {
        public TRepository Repository { get; private set; }

        public BaseManager(TRepository repository)
        {
            Repository = repository;
        }

        public List<T> GetAll()
        {
            return Repository.GetList();
        }
        public Task<List<T>> GetAllAsync()
        {
            return Repository.GetListAsync();
        }

        public T GetById(TKey id)
        {
            return Repository.Get(p => EqualityComparer<TKey>.Default.Equals(id, p.Id));
        }
        public Task<T> GetByIdAsync(TKey id)
        {
            return Repository.GetAsync(p => EqualityComparer<TKey>.Default.Equals(id, p.Id));
        }

        public bool ItemExists(TKey id)
        {
            return Repository.ItemExists(p => EqualityComparer<TKey>.Default.Equals(id, p.Id));
        }
        public Task<bool> ItemExistsAsync(TKey id)
        {
            return Repository.ItemExistsAsync(p => EqualityComparer<TKey>.Default.Equals(id, p.Id));
        }

        public void Create(T entity)
        {
            Repository.Create(entity);
        }

        public ValueTask<EntityEntry<T>> CreateAsync(T entity)
        {
            return Repository.CreateAsync(entity);
        }

        public void Update(T entity)
        {
            Repository.Update(entity);
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            Repository.DeleteRange(entities);
        }

        public void SaveChanges()
        {
            Repository.Save();
        }
        public Task SaveChangesAsync()
        {
            return Repository.SaveAsync();
        }
    }
}
