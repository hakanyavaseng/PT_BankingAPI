using BankingAPI.Service.Interfaces;
using BankingAPI.Service.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BankingAPI.Service
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            ConfigureMapping(services);
            RegisterServices(services);
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            //services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICreditCardService, CreditCartService>();
            services.AddScoped<IDebitCardService, DebitCartService>();
        }

        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
   
}
