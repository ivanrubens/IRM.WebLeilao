using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Patterns.Repository;

namespace IRM.WebLeilao.Api.Infra.Data.Repositories
{
    public class PessoaRepository
    {
        private readonly IRepository<Pessoa> _repo;

        public PessoaRepository(Patterns.Repository.IRepository<Pessoa> repo)
        {
            _repo = repo;
        }

        public async Task<Pessoa> Incluir(Pessoa entity)
        {
            return await _repo.Incluir(entity);
        }

        public async Task<Pessoa> Alterar(Pessoa entity)
        {
            return await _repo.Alterar(entity);
        }

        public async Task<Pessoa> Excluir(Guid id)
        {
            return await _repo.Excluir(id);
        }

        public async Task<Pessoa> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<IEnumerable<Pessoa>> Obter()
        {
            return await _repo.Obter();
        }
    }
}