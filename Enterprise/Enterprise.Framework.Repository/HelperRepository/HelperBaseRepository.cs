using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Enterprise.Framework.Repository.Abstract;
using Enterprise.Framework.DataLayers;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Enterprise.Framework.Repository.HelperRepository
{
    public class HelperBaseRepository<T> : BaseDispose, IEntityBaseRepository<T> where T : class, new()
    {
        private readonly HelperContext _context;
        public HelperBaseRepository(HelperContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            DbEntityEntry entityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.AsEnumerable();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public void Delete(T entity)
        {
            DbEntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public override void Dispose()
        {
            base.Dispose(_context);
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.FirstOrDefault(predicate);
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
