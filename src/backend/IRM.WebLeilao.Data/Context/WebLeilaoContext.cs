using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IRM.WebLeilao.Data.Context
{
    public sealed class WebLeilaoContext : DbContext
    {
        //public DbSet<Blog> Blogs { get; set; }
        //public DbSet<Post> Posts { get; set; }
        static string schemaDefault = "webleilao";

        public WebLeilaoContext(DbContextOptions<WebLeilaoContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schemaDefault);

            //modelBuilder.ApplyConfiguration(new BlogMapping());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebLeilaoContext).Assembly); // Novo método para mapeamento (via reflection)

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseNpgsql(DatabaseConfig.ConnectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", schemaDefault));
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}