using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using IRM.WebLeilao.Api.Application.AutoMapper;

namespace IRM.WebLeilao.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetAssembly(typeof(DomainToDTOMappingProfile)));
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        }
    }
}