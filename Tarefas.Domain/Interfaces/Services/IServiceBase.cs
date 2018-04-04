using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Adicionar(TEntity obj);
        void Remover(TEntity obj);
        void Atualizar(TEntity obj);
    }
}
