using System;
using System.Threading.Tasks;

namespace IRM.WebLeilao.Api.Data.Patterns.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> ObterPorId(Guid id);
        Task<TEntity> Incluir(TEntity entity);
        Task<TEntity> Alterar(TEntity entity);
        Task<TEntity> Excluir(Guid id);
      }
}