using System;
using System.Threading.Tasks;
using AutoMapper;
using Flunt.Notifications;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Repositories;

namespace IRM.WebLeilao.Api.Domain.Services
{
    public class PessoaService : Notifiable
    {
        private readonly IMapper _mapper;
        private readonly PessoaRepository _PessoaRepository;

        public PessoaService(IMapper mapper,
                                  PessoaRepository PessoaRepository)
        {
            _mapper = mapper;
            _PessoaRepository = PessoaRepository;
        }

        public async Task Incluir(Pessoa entity)
        {
            await _PessoaRepository.Incluir(entity);
        }

        public async Task Alterar(Pessoa entity)
        {
            await _PessoaRepository.Alterar(entity);
        }

        public async Task Excluir(Guid id)
        {
            await _PessoaRepository.Excluir(id);
        }

        public async Task<Pessoa> ObterPorId(Guid id)
        {
            return await _PessoaRepository.ObterPorId(id);
        }
    }
}