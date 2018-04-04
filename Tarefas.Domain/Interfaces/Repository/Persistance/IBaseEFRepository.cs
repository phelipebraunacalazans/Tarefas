using System;

namespace Tarefas.Domain.Interfaces.Repository.Persistance
{
    public interface IBaseEFRepository<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
    }
}
