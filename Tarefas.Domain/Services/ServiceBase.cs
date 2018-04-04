using Tarefas.Domain.Interfaces.Repository.Persistance;
using Tarefas.Domain.Interfaces.Services;

namespace Tarefas.Domain.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IBaseEFRepository<TEntity> _baseEFRepository;

        protected ServiceBase(IBaseEFRepository<TEntity> repositoryEF)
        {
            _baseEFRepository = repositoryEF;
        }
                
        public virtual void Adicionar(TEntity obj)
        {
            _baseEFRepository.Adicionar(obj);
        }

        public virtual void Atualizar(TEntity obj)
        {
            _baseEFRepository.Atualizar(obj);
        }
        
        public virtual void Remover(TEntity obj)
        {
            _baseEFRepository.Remover(obj);
        }

        public void Dispose()
        {
            _baseEFRepository.Dispose();
        }
    }
}
