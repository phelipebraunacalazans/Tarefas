using System;
using Tarefas.Infrastructure.Data.Context;
using Tarefas.Infrastructure.Data.Interfaces;

namespace Tarefas.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TarefasEFContext _context;

        public UnitOfWork(TarefasEFContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
