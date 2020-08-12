using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Repositories;

namespace IRM.WebLeilao.Api.Domain.Services
{
    public class LeilaoService : Notifiable
    {
        private readonly IMapper _mapper;
        private readonly LeilaoRepository _leilaoRepository;

        public LeilaoService(IMapper mapper,
                             LeilaoRepository leilaoRepository)
        {
            _mapper = mapper;
            _leilaoRepository = leilaoRepository;
        }

        public async Task<Leilao> Incluir(Leilao leilao)
        {
            return await _leilaoRepository.Incluir(leilao);
        }

        public async Task<Leilao> Alterar(Leilao leilao)
        {
            return await _leilaoRepository.Alterar(leilao);
        }

        public async Task<Leilao> Excluir(Guid id)
        {
            return await _leilaoRepository.Excluir(id);
        }

        public async Task<Leilao> ObterPorId(Guid id)
        {
            return await _leilaoRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Leilao>> Obter()
        {
            return await _leilaoRepository.Obter();
        }
    }
}