using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Application.ViewModels;

namespace Tarefas.Application.Interfaces
{
    public interface ITarefaAppService : IDisposable
    {
        bool Adicionar(TarefaViewModel tarefa);
        bool Remover(TarefaViewModel tarefa);
        bool Atualizar(TarefaViewModel tarefa);
        Task<IEnumerable<TarefaViewModel>> BuscarTarefasAtivas();
        Task<TarefaViewModel> BuscarPorId(Guid id);
        Task<IEnumerable<TarefaViewModel>> BuscarTodos();
    }
}
