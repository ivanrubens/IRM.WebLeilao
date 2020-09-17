using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IRM.WebLeilao.Api.Domain.Models;

namespace IRM.WebLeilao.Api.Infra.Data.Mappings
{
    public class LeilaoMapping : BaseMapping<Leilao>
    {
        public override void Configure(EntityTypeBuilder<Leilao> builder)
        {
            base.Configure(builder);
            builder.ToTable("leilao");

            builder.Property(x => x.ValorInicial)
               .HasColumnName("valor_inicial");

            builder.Property(x => x.ItemUsado)
                .HasColumnName("item_usado"); 

            builder.Property(x => x.DataAbertura)
                .HasColumnName("data_abertura"); 

            builder.Property(x => x.DataFinalizacao)
                .HasColumnName("data_finalizacao"); 

            builder.HasIndex(i => i.Ativo);
        }
    }
}
