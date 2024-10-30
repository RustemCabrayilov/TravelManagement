    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TravelingManagementSystem.Persistence.Context;

    namespace TravelingManagementSystem.Persistence.Extensions;

    public static class ServiceRegister
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts=>
            {
                opts.UseSqlServer(configuration.GetConnectionString("SqlConnectionString"));
            });
        }
    }