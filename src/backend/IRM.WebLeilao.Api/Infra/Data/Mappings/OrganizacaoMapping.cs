﻿using Microsoft.EntityFrameworkCore;
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

            builder.HasIndex(i => i.Ativo);
        }
    }
}
