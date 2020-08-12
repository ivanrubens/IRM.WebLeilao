using System;
using System.Collections.Generic;
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

        public async Task<Organizacao> Incluir(Organizacao entity)
        {
            return await _repo.Incluir(entity);
        }

        public async Task<Organizacao> Alterar(Organizacao entity)
        {
            return await _repo.Alterar(entity);
        }

        public async Task<Organizacao> ExcluirAsync(Guid id)
        {
            return await _repo.Excluir(id);
        }

        public async Task<Organizacao> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<IEnumerable<Organizacao>> Obter()
        {
            return await _repo.Obter();
        }
    }
}