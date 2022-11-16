using System.Linq.Expressions;
using ComercioElectronico.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComercioElectronico.Infraestructure;

public class EfRepository<TEntity,TEntityId> : IRepository<TEntity,TEntityId> where TEntity : class
{
    protected readonly ComercioElectronicoDbContext _context;

    public IUnitOfWork UnitOfWork =>_context;    
    
    public EfRepository(ComercioElectronicoDbContext context)
    {
        _context = context;
    }

    

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public bool Delete(TEntity entity)
    {
        if(_context.Set<TEntity>().Remove(entity)==null)
        {
            return false;
        }
        else
        {
            return true;
        }
        //return true;
    }

    public IQueryable<TEntity> GetAll(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _context.Set<TEntity>().AsNoTracking();
        else
            return _context.Set<TEntity>().AsQueryable();
    }

    public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> queryable = GetAll();
        foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties)
        {
            queryable = queryable.Include<TEntity, object>(includeProperty);
        }

        return queryable;
    }

    public async Task<TEntity> GetByIdAsync(TEntityId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
        
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        
        return;
    }
}
