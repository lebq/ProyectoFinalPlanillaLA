using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Galaxy.Bank.Persistence
{
    public static class InjectionsDependecy
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Configuration.Context.BankDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbBank"));
            });

            return services;
        }
    }
}
