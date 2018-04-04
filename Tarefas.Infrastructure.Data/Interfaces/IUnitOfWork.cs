using System;
using System.Collections.Generic;
using System.Text;

namespace Tarefas.Infrastructure.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
