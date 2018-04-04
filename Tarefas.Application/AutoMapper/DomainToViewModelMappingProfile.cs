using AutoMapper;
using Tarefas.Application.ViewModels;
using Tarefas.Domain.Entities;

namespace Tarefas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tarefa, TarefaViewModel>();
        }
    }
}
