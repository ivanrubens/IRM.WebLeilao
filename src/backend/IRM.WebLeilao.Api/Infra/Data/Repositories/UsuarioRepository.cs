using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IRM.WebLeilao.Api.Domain.Models;
using IRM.WebLeilao.Api.Infra.Data.Patterns.Repository;

namespace IRM.WebLeilao.Api.Infra.Data.Repositories
{
    public class UsuarioRepository
    {
        private readonly IRepository<Usuario> _repo;

        public UsuarioRepository(Patterns.Repository.IRepository<Usuario> repo)
        {
            _repo = repo;
        }

        public async Task<Usuario> Incluir(Usuario entity)
        {
            return await _repo.Incluir(entity);
        }

        public async Task<Usuario> Alterar(Usuario entity)
        {
            return await _repo.Alterar(entity);
        }

        public async Task<Usuario> Excluir(Guid id)
        {
            return await _repo.Excluir(id);
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task<IEnumerable<Usuario>> Obter()
        {
            return await _repo.Obter();
        }

    }
}