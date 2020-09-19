using Microsoft.Extensions.DependencyInjection;
using MS.Customer.Application.Abstraction.src.Customer;
using MS.Customer.Application.src.CustomerServices;
using MS.Customer.Persistence.src.Repository;

namespace MS.Customer.Infastructure.src.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterExternalServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
