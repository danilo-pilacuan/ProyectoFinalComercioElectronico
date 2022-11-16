using System.Linq.Expressions;

namespace ComercioElectronico.Domain;

public interface IRepository<TEntity,TEntityId> where TEntity:class
{
    IUnitOfWork UnitOfWork { get; }
    IQueryable<TEntity> GetAll(bool asNoTracking = true);

    Task<TEntity> GetByIdAsync(TEntityId id);

    Task<TEntity> AddAsync(TEntity entity);

    Task UpdateAsync (TEntity entity);

    bool  Delete(TEntity entity);

    IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
}
