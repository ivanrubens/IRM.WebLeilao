using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IRM.WebLeilao.Api.Domain.Models;

namespace IRM.WebLeilao.Api.Infra.Data.Mappings
{
    public class OrganizacaoMapping : BaseMapping<Organizacao>
    {
        public override void Configure(EntityTypeBuilder<Organizacao> builder)
        {
            base.Configure(builder);
            builder.ToTable("organizacao");

            /* 
            builder.Property(x => x.MunicipioId)
                .HasColumnName("municipio_id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Coordenada)
               .HasColumnName("coordenada")
               .HasMaxLength(150);

            builder.Property(x => x.DefaultNaoInformado)
                .HasColumnName("default_nao_informado"); 
            */

            builder.HasIndex(i => i.Ativo);
        }
    }
}
