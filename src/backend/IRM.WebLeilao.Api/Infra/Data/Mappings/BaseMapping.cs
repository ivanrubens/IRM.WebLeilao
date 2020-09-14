using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IRM.WebLeilao.Api.Domain.Models;

namespace IRM.WebLeilao.Api.Infra.Data.Mappings
{
    public class BaseMapping<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.InclusaoTimestamp)
                .HasColumnName("inclusao_timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(x => x.InclusaoUsuarioId)
                .HasColumnName("inclusao_usuario_id")
                .IsRequired(true);

            builder.Property(x => x.AlteracaoTimestamp)
                .HasColumnName("alteracao_timestamp")
                .IsRequired(false);

            builder.Property(x => x.AlteracaoUsuarioId)
                .HasColumnName("alteracao_usuario_id")
                .IsRequired(false);

            builder.Property(x => x.ExclusaoTimestamp)
                .HasColumnName("exclusao_timestamp")
                .IsRequired(false);
                
            builder.Property(x => x.ExclusaoUsuarioId)
                .HasColumnName("exclusao_usuario_id")
                .IsRequired(false);

            builder.Property(x => x.Ativo)
                .HasColumnName("ativo")
                .IsRequired();
            
            builder.HasIndex(x => x.InclusaoTimestamp);
            builder.HasIndex(x => x.Ativo);
        }
    }
}
