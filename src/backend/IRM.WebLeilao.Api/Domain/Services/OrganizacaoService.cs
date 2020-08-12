using System;
using System.Collections.Generic;
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

        public async Task<Organizacao> Incluir(Organizacao entity)
        {
            return await _organizacaoRepository.Incluir(entity);
        }

        public async Task<Organizacao> Alterar(Organizacao entity)
        {
            return await _organizacaoRepository.Alterar(entity);
        }

        public async Task<Organizacao> Excluir(Guid id)
        {
            return await _organizacaoRepository.ExcluirAsync(id);
        }

        public async Task<Organizacao> ObterPorId(Guid id)
        {
            return await _organizacaoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Organizacao>> Obter()
        {
            return await _organizacaoRepository.Obter();
        }
    }
}