using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Application.Interfaces;
using Tarefas.Application.ViewModels;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Services;
using Tarefas.Infrastructure.Data.Interfaces;

namespace Tarefas.Application.Services
{
    public class TarefaAppService : ApplicationServiceBase, ITarefaAppService
    {
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefaAppService(ITarefaService tarefaService, IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _tarefaService = tarefaService;
            _mapper = mapper;
        }

        public bool Adicionar(TarefaViewModel tarefaViewModel)
        {
            var sucesso = true;

            try
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
                tarefa.SetDataCriacao(DateTime.Now);
                _tarefaService.Adicionar(tarefa);

                sucesso = Commit();
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return sucesso;
        }

        public bool Atualizar(TarefaViewModel tarefaViewModel)
        {
            var sucesso = true;

            try
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
                tarefa.SetDataAlteracao(DateTime.Now);
                _tarefaService.Atualizar(tarefa);

                sucesso = Commit();
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return sucesso;
        }

        public bool Remover(TarefaViewModel tarefaViewModel)
        {
            var sucesso = true;

            try
            {
                var tarefa = _mapper.Map<Tarefa>(tarefaViewModel);
                tarefa.SetDataExclusao(DateTime.Now);
                _tarefaService.Remover(_mapper.Map<Tarefa>(tarefa));

                sucesso = Commit();
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return sucesso;
        }

        public async Task<IEnumerable<TarefaViewModel>> BuscarTarefasAtivas()
        {
            var tarefasAtivas = new List<TarefaViewModel>();

            try
            {
                tarefasAtivas = _mapper.Map<List<TarefaViewModel>>(await _tarefaService.BuscarTarefasAtivas());
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return tarefasAtivas;
        }

        public async Task<TarefaViewModel> BuscarPorId(Guid id)
        {
            TarefaViewModel tarefa = null;
            
            try
            {
                tarefa = _mapper.Map<TarefaViewModel>(await _tarefaService.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return tarefa;
        }

        public async Task<IEnumerable<TarefaViewModel>> BuscarTodos()
        {
            var tarefas = new List<TarefaViewModel>();

            try
            {
                tarefas = _mapper.Map<List<TarefaViewModel>>(await _tarefaService.BuscarTodos());
            }
            catch (Exception ex)
            {
                //TODO: Log                
            }

            return tarefas;
        }

        public void Dispose()
        {
            _tarefaService.Dispose();
        }
    }
}
