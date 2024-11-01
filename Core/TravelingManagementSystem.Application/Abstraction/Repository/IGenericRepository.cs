using TravelingManagementSystem.Domain.Entities;

namespace TravelingManagementSystem.Application.Abstraction.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
 ValueTask<bool> AddAsync(T entity);
 bool Remove(T entity);
 Task<T> GetAsync(Guid id);
 IQueryable<T> GetAll();
 bool Update(T entity);
}