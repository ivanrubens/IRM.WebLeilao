using System;
using System.Threading.Tasks;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Patterns.Repository;

namespace IRM.WebLeilao.Api.Infra.Data.Repositories
{
    public class OrganizacaoRepository
    {
        private readonly IRepository<Organizacao> _repo;

        public OrganizacaoRepository(Patterns.Repository.IRepository<Organizacao> repo)
        {
            _repo = repo;
        }

        public async Task Incluir(Organizacao entity)
        {
            await _repo.Incluir(entity);
        }

        public async Task Alterar(Organizacao entity)
        {
            await _repo.Alterar(entity);
        }

        public async Task ExcluirAsync(Guid id)
        {
            await _repo.Excluir(id);
        }

        public async Task<Organizacao> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }
    }
}