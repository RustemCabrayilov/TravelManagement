using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Persistence.Context;

namespace TravelingManagementSystem.Persistence.UnitOfWork;

public class UnitOfWork(AppDbContext _dbContext):IUnitOfWork 
{
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}