using BankingAPI.Data.Contexts;
using BankingAPI.Data.Repositories;
using BankingAPI.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingAPI.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankingDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            ConfigureRepositories(services);
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
