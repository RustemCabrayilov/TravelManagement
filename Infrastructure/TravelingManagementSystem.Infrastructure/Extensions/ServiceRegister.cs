using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Infrastructure.Services.InternalServices;

namespace TravelingManagementSystem.Infrastructure.Extensions;

public static class ServiceRegister
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IGuideService, GuideService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
    
}