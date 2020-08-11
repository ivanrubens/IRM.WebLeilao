using System;
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

        public async Task Incluir(Leilao entity)
        {
            await _leilaoRepository.Incluir(entity);
        }

        public async Task Alterar(Leilao entity)
        {
            await _leilaoRepository.Alterar(entity);
        }

        public async Task Excluir(Guid id)
        {
            await _leilaoRepository.Excluir(id);
        }

        public async Task<Leilao> ObterPorId(Guid id)
        {
            return await _leilaoRepository.ObterPorId(id);
        }
    }
}