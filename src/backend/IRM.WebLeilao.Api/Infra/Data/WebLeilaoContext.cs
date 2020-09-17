using System;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using IRM.WebLeilao.Api.Configurations;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IRM.WebLeilao.Api.Infra.Data
{
    public class WebLeilaoContext : DbContext
    {
        public DbSet<Organizacao> Organizacao { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Leilao> Leilao { get; set; }

        static string schemaDefault = "webleilao";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(schemaDefault);

            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<Organizacao>().OwnsOne(p => p.CNPJ);
            modelBuilder.Entity<Organizacao>().OwnsOne(p => p.NomeFantasia);
            modelBuilder.Entity<Organizacao>().OwnsOne(p => p.RazaoSocial);
            modelBuilder.Entity<Pessoa>().OwnsOne(p => p.CPF);
            modelBuilder.Entity<Pessoa>().OwnsOne(p => p.Nome);
            modelBuilder.Entity<Leilao>().OwnsOne(p => p.NomeLeilao);

            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;

            modelBuilder.ApplyConfiguration(new LeilaoMapping());
            modelBuilder.ApplyConfiguration(new OrganizacaoMapping());
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(DatabaseConfig.ConnectionString, x => x.MigrationsHistoryTable("__EFMigrationsHistory", schemaDefault));
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