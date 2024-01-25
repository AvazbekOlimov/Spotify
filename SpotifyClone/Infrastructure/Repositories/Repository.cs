using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext) : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task AddAsync(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _dbContext.Set<TEntity>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("ID must be greater then 0", nameof(id));
        }
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var existingEntity = await GetByIdAsync(entity.Id);

        if (existingEntity == null)
        {
            throw new ArgumentException($"Entity with Id {entity} not found.", nameof(entity));
        }

        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

        await _dbContext.SaveChangesAsync();
    }
}
