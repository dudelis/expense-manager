﻿using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Interfaces;
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

        public T GetById(TKey id)
        {
            return Repository.Get(p => EqualityComparer<TKey>.Default.Equals(id, p.Id));
        }

        public bool ItemExists(TKey id)
        {
            return Repository.ItemExists(p => EqualityComparer<TKey>.Default.Equals(id, p.Id));
        }

        public void Create(T entity)
        {
            Repository.Create(entity);
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
