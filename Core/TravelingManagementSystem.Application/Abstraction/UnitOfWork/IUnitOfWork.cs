namespace TravelingManagementSystem.Application.Abstraction.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
    void SaveChanges();
}