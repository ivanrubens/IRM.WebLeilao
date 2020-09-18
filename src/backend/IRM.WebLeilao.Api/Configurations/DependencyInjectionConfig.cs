using Microsoft.Extensions.DependencyInjection;
using IRM.WebLeilao.Api.Infra.Data;
using IRM.WebLeilao.Api.Infra.Data.Patterns.RepositoryPattern;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using IRM.WebLeilao.Api.Domain.Services;

namespace IRM.WebLeilao.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Infra - Data
            services.AddScoped<WebLeilaoContext>();
            services.AddScoped<DbContext, WebLeilaoContext>();

            services.AddScoped<IRepository<Organizacao>, Repository<Organizacao>>();
            services.AddScoped<IRepository<Pessoa>, Repository<Pessoa>>();
            services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
            services.AddScoped<IRepository<Leilao>, Repository<Leilao>>();

            services.AddScoped<OrganizacaoRepository>();
            services.AddScoped<PessoaRepository>();
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<LeilaoRepository>();

            services.AddScoped<OrganizacaoService>();
            services.AddScoped<PessoaService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<LeilaoService>();

            /*
            services.AddScoped<PessoaService>();
            services.AddScoped<UsuarioService>();
            services.AddScoped<LeilaoService>();
            services.AddScoped<OrganizacaoRepository>();
            services.AddScoped<PessoaRepository>();
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<LeilaoRepository>();
            services.AddScoped<IRepository<Leilao>,Repository<Leilao>>(); 
            */
        }
    }
}