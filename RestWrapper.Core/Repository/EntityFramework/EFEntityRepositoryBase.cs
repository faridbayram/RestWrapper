using Microsoft.EntityFrameworkCore;
using RestWrapper.Entities.Abstract;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RestWrapper.Core.Repository.EntityFramework
{
    public class EFEntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntityDAO, new()
    {
        protected readonly TContext _context;

        public EFEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(f => f.Id == id);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                    ? _context.Set<TEntity>()
                    : _context.Set<TEntity>().Where(filter);
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
        
        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
