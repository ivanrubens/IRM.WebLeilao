using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRM.WebLeilao.Api.Infra.Data.Patterns.RepositoryPattern
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorId(Guid id);
        Task<TEntity> Incluir(TEntity entity);
        Task<TEntity> Alterar(TEntity entity);
        Task<TEntity> Excluir(Guid id);
        Task<IEnumerable<TEntity>> Obter();
    }
}