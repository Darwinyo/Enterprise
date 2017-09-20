using Enterprise.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Repository.UserRepository
{
    public class UserBaseRepository<T> : BaseDispose, IEntityBaseRepository<T> where T : class, new()
    {
        protected readonly UserContext _context;
        public UserBaseRepository(UserContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }

        public IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var IncludeProperty in includeProperties)
            {
                queryable = queryable.Include(IncludeProperty);
            }
            return queryable.AsEnumerable();
        }

        public virtual int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual void Delete(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
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

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll()
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
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
