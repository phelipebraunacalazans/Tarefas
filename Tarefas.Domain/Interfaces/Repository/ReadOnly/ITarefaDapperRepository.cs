using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Repository.ReadOnly
{
    public interface ITarefaDapperRepository : IDisposable, IBaseDapperRepository
    {
        Task<IEnumerable<Tarefa>> BuscarTarefasAtivas();
        Task<Tarefa> BuscarPorId(Guid id);
        Task<IEnumerable<Tarefa>> BuscarTodos();
    }
}
