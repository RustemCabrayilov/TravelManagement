using Microsoft.EntityFrameworkCore;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Domain.Entities;
using TravelingManagementSystem.Persistence.Context;

namespace TravelingManagementSystem.Persistence.Repository;

public class GenericRepository<T>(AppDbContext _dbContext) : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = _dbContext.Set<T>();

    public async ValueTask<bool> AddAsync(T entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public bool Remove(T entity)
    {
        var entityEntry = _dbSet.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var query = _dbSet.AsQueryable().AsNoTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<T> GetAll()
    {
        var query = _dbSet.AsQueryable().AsNoTracking();
        return query;
    }

    public bool Update(T entity)
    {
        var entityEntry = _dbSet.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
}