using System;
using System.Linq;
using System.Linq.Expressions;
using RestWrapper.Entities.Abstract;

namespace RestWrapper.Core.Repository
{
    public interface IEntityRepository<TEntity>
        where TEntity : BaseEntityDAO, new()
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        TEntity GetById(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entity);
    }
}
