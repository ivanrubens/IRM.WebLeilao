using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IRM.WebLeilao.Api.Domain.Models;

namespace IRM.WebLeilao.Api.Infra.Data.Mappings
{
    public class UsuarioMapping : BaseMapping<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);
            builder.ToTable("usuario");

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(x => x.SessaoId)
                .HasColumnName("sessao_id")
                .HasMaxLength(150);

            builder.HasIndex(i => i.Ativo);
            builder.HasIndex(i => i.UserId);
            builder.HasIndex(i => i.SessaoId);
        }
    }
}
