using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Domain.Entities;
using TravelingManagementSystem.Persistence.Context;

namespace TravelingManagementSystem.Persistence.Repository;

public class GenericRepository<T>(AppDbContext _context) : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet = _context.Set<T>();

    public async ValueTask<bool> AddAsync(T entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public bool Remove(T entity)
    {
       var entityEntry = _dbSet.Remove(entity);
       return  entityEntry.State == EntityState.Deleted;
    }

    public async Task<T> GetAsync(Guid id)
    {
        var entities = _dbSet.AsQueryable().AsNoTracking();
      return await entities.FirstOrDefaultAsync();
    }

    public IQueryable<T> GetAll(Guid id)
    {
       return _dbSet.AsQueryable().AsNoTracking();
    }

    public bool Update(T entity)
    {
        var entityEntry = _dbSet.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
}