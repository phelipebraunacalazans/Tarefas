using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repository.Persistance;
using Tarefas.Infrastructure.Data.Context;

namespace Tarefas.Infrastructure.Data.Repository.Persistance
{
    public class TarefaEFRepository : BaseEFRepository<Tarefa>, ITarefaEFRepository
    {
        public TarefaEFRepository(TarefasEFContext efContext) : base(efContext)
        {

        }
    }
}
