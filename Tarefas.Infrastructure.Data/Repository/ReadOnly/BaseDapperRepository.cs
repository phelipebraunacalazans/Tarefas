using Tarefas.Domain.Interfaces.Repository.ReadOnly;
using Tarefas.Infrastructure.Data.Context;

namespace Tarefas.Infrastructure.Data.Repository.ReadOnly
{
    public abstract class BaseDapperRepository : IBaseDapperRepository
    {
        protected readonly TarefasDapperContext dapperContext;

        protected BaseDapperRepository(TarefasDapperContext tarefasDapperContext)
        {
            dapperContext = tarefasDapperContext;
        }
        
        public void Dispose()
        {
            dapperContext.Dispose();            
        }
    }
}
