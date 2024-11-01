using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelingManagementSystem.Application.Abstraction.Repository;
using TravelingManagementSystem.Application.Abstraction.UnitOfWork;
using TravelingManagementSystem.Persistence.Context;
using TravelingManagementSystem.Persistence.Repository;

namespace TravelingManagementSystem.Persistence.Extensions;

public static class ServiceRegister
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration conifguration)
    {
        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(conifguration.GetConnectionString("SqlConnectionString"))
        );
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}