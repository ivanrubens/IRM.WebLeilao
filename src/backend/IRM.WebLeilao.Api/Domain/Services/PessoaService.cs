using System;
using System.Collections.Generic;
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

        public async Task<Pessoa> Incluir(Pessoa entity)
        {
            return await _PessoaRepository.Incluir(entity);
        }

        public async Task<Pessoa> Alterar(Pessoa entity)
        {
            return await _PessoaRepository.Alterar(entity);
        }

        public async Task<Pessoa> Excluir(Guid id)
        {
            return await _PessoaRepository.Excluir(id);
        }

        public async Task<Pessoa> ObterPorId(Guid id)
        {
            return await _PessoaRepository.ObterPorId(id);
        }

        public async Task<IEnumerable<Pessoa>> Obter()
        {
            return await _PessoaRepository.Obter();
        }
    }
}