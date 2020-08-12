using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Patterns.Repository;

namespace IRM.WebLeilao.Api.Infra.Data.Repositories
{
    public class LeilaoRepository
    {
        private readonly IRepository<Leilao> _repo;

        public LeilaoRepository(Patterns.Repository.IRepository<Leilao> repo)
        {
            _repo = repo;
        }

        public async Task<Leilao> Incluir(Leilao entity)
        {
            return await _repo.Incluir(entity);
        }

        public async Task<Leilao> Alterar(Leilao entity)
        {
            return await _repo.Alterar(entity);
        }

        public async Task<Leilao> Excluir(Guid id)
        {
            return await _repo.Excluir(id);
        }

        public async Task<Leilao> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<IEnumerable<Leilao>> Obter()
        {
            return await _repo.Obter();
        }
    }
}