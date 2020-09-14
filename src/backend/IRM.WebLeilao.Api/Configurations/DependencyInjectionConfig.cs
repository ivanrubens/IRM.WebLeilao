using Microsoft.Extensions.DependencyInjection;
using IRM.WebLeilao.Api.Infra.Data;

namespace IRM.WebLeilao.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<WebLeilaoContext>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();

        }
    }
}