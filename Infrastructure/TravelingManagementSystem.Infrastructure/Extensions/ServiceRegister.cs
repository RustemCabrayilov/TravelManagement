using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TravelingManagementSystem.Application.Abstraction.Services;
using TravelingManagementSystem.Infrastructure.Services.InternalServices;
using TravelingManagementSystem.Infrastructure.Validation;

namespace TravelingManagementSystem.Infrastructure.Extensions;

public static class ServiceRegister
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IGuideService, GuideService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(CustomerValidator)));
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(GroupValidator)));
        services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(GuideValidator)));
        /*ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("az");*/
    }
    
}