using AutoMapper;
using IRM.WebLeilao.Api.Application.ViewModel;
using IRM.WebLeilao.Api.Domain.Models;

namespace IRM.WebLeilao.Api.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Organizacao, OrganizacaoViewModel>()
               .ForMember(d => d.CNPJ, o => o.MapFrom(s => s.CNPJ.Numero))
               .ForMember(d => d.RazaoSocial, o => o.MapFrom(s => s.RazaoSocial.Nome))
               .ForMember(d => d.NomeFantasia, o => o.MapFrom(s => s.NomeFantasia.Nome))
               .ReverseMap()
            ;
        }
    }
}
