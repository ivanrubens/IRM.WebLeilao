using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IRM.WebLeilao.Api.Data.Context;

namespace IRM.WebLeilao.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static string ConnectionString
        {
            get; set;
        }
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            ConnectionString = configuration.GetConnectionString("WebLeilaoConnection");

            services.AddDbContext<WebLeilaoContext>(options =>
                options.UseNpgsql(ConnectionString));

            //services.UseNpgsql(DatabaseConfig.ConnectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", schemaDefault));

        }
    }
}