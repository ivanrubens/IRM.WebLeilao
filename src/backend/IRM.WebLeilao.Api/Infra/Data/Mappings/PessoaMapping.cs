using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IRM.WebLeilao.Api.Domain.Models;

namespace IRM.WebLeilao.Api.Infra.Data.Mappings
{
    public class PessoaMapping : BaseMapping<Pessoa>
    {
        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder);
            builder.ToTable("pessoa");

            builder.HasIndex(i => i.Ativo);
        }
    }
}
