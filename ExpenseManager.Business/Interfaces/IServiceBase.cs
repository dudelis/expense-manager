﻿using ExpenseManager.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Business.Interfaces
{
    public interface IServiceBase<T> where T: class, IEntity, new()
    {
        List<T> GetAll();
        T GetById(int id);
        bool ItemExists(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
    public interface IServiceBase<T, TPrimaryKey> where T : class, IEntity<TPrimaryKey>, new()
    {
        List<T> GetAll();
        T GetById(TPrimaryKey id);
        bool ItemExists(TPrimaryKey id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}