using System;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Repositories;

namespace IRM.WebLeilao.Api.Domain.Services
{
    public class OrganizacaoService : Notifiable
    {
        private readonly IMapper _mapper;
        private readonly OrganizacaoRepository _organizacaoRepository;

        public OrganizacaoService(IMapper mapper,
                                  OrganizacaoRepository organizacaoRepository)
        {
            _mapper = mapper;
            _organizacaoRepository = organizacaoRepository;
        }

        public async Task Incluir(Organizacao entity)
        {
            await _organizacaoRepository.Incluir(entity);
        }

        public async Task Alterar(Organizacao entity)
        {
            await _organizacaoRepository.Alterar(entity);
        }

        public async Task Excluir(Guid id)
        {
            await _organizacaoRepository.ExcluirAsync(id);
        }

        public async Task<Organizacao> ObterPorId(Guid id)
        {
            return await _organizacaoRepository.ObterPorId(id);
        }
    }
}