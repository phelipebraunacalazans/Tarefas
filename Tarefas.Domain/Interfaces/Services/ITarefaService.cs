using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Services
{
    public interface ITarefaService : IServiceBase<Tarefa>
    {        
        Task<IEnumerable<Tarefa>> BuscarTarefasAtivas();
        Task<Tarefa> BuscarPorId(Guid id);
        Task<IEnumerable<Tarefa>> BuscarTodos();
    }
}
