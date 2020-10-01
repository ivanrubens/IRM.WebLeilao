using AutoMapper;
using IRM.WebLeilao.Api.Application.ViewModel;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Domain.ValueObjects;

namespace IRM.WebLeilao.Api.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<string, CNPJ>()
                .ConstructUsing(p => new CNPJ(p));

            CreateMap<string, RazaoSocial>()
                .ConstructUsing(p => new RazaoSocial(p));

            CreateMap<string, NomeFantasia>()
                .ConstructUsing(p => new NomeFantasia(p));


            /* CreateMap<OrganizacaoViewModel, CNPJ>()
                .ConstructUsing(p =>
                    new CNPJ(p.CNPJ));

            CreateMap<OrganizacaoViewModel, RazaoSocial>()
                .ConstructUsing(p =>
                    new RazaoSocial(p.RazaoSocial));

            CreateMap<OrganizacaoViewModel, NomeFantasia>()
                .ConstructUsing(p =>
                    new NomeFantasia(p.NomeFantasia)); */
        }
    }
}