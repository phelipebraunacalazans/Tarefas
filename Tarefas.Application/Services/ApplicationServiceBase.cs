using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Infrastructure.Data.Interfaces;

namespace Tarefas.Application.Services
{
    public abstract class ApplicationServiceBase
    {            
        private readonly IUnitOfWork _unitOfWork;

        protected ApplicationServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Commit()
        {
            return _unitOfWork.Commit();
        }
    }
}
