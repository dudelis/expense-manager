using ExpenseManager.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            this._context = context;
        }

        public void Create(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return this._context.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? this._context.Set<TEntity>().AsNoTracking().ToList() :
                this._context.Set<TEntity>().Where(filter).ToList();
        }

        public bool ItemExists(Expression<Func<TEntity, bool>> filter)
        {
            return this._context.Set<TEntity>().Any(filter);
        }

        public void Update(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
        }
    }
}
