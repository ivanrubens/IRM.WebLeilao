using System;
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

        public async Task Incluir(Usuario entity)
        {
            await _repo.Incluir(entity);
        }

        public async Task Alterar(Usuario entity)
        {
            await _repo.Alterar(entity);
        }

        public async Task Excluir(Guid id)
        {
            await _repo.Excluir(id);
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _repo.ObterPorId(id);
        }
    }
}