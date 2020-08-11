using System;
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

        public async Task Incluir(Leilao entity)
        {
            await _repo.Incluir(entity);
        }

        public async Task Alterar(Leilao entity)
        {
            await _repo.Alterar(entity);
        }

        public async Task Excluir(Guid id)
        {
            await _repo.Excluir(id);
        }

        public async Task<Leilao> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }
    }
}