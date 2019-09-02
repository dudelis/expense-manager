using ExpenseManager.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : EfEntityRepositoryBase<TEntity, int, TContext>
        where TEntity: class, IEntity, new()
        where TContext : DbContext
    {
        public EfEntityRepositoryBase(TContext context): base(context)
        {
        }


    }
    public class EfEntityRepositoryBase<TEntity, TKey, TContext> : IEntityRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
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
        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this._context.Set<TEntity>().Where(filter).FirstOrDefaultAsync();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = this._context.Set<TEntity>().Include(_context.GetIncludePaths(typeof(TEntity)));
            if (filter != null)
                query = query.Where(filter);
            return query.ToList();
        }
        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = this._context.Set<TEntity>().Include(_context.GetIncludePaths(typeof(TEntity)));
            if (filter != null)
                query = query.Where(filter);
            return query.ToListAsync();
        }

        public bool ItemExists(Expression<Func<TEntity, bool>> filter)
        {
            return this._context.Set<TEntity>().AsNoTracking().Any(filter);
        }
        public Task<bool> ItemExistsAsync(Expression<Func<TEntity, bool>> filter)
        {
            return this._context.Set<TEntity>().AsNoTracking().AnyAsync(filter);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return this._context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
        }
    }
}
