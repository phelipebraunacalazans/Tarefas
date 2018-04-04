using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Interfaces.Repository.Persistance;
using Tarefas.Infrastructure.Data.Context;

namespace Tarefas.Infrastructure.Data.Repository.Persistance
{
    public abstract class BaseEFRepository<TEntity> : IBaseEFRepository<TEntity> where TEntity : class
    {     
        protected TarefasEFContext Db;
        protected DbSet<TEntity> DbSet;

        protected BaseEFRepository(TarefasEFContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remover(TEntity obj)
        {            
            DbSet.Remove(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
