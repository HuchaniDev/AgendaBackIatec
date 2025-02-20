using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Repositories.Common;
using Schedule.Infrastructure.Database.EF.Context;
using Schedule.Infrastructure.Database.EF.Entities;

namespace Schedule.Infrastructure.Database.EF.Repositories.Common;


public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, IIdentifiable
{
    public readonly ScheduleBdContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(
        ScheduleBdContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<bool> DeleteHardAsync(int id)
    {
        var del = await _dbSet.FindAsync(id);
        if (del is null) return false;
        _dbSet.Remove(del);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsByIdAsync(int id)
    {
        return await _dbSet.AnyAsync(e => e.Id == id);
    }
}