using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarefas.Application.Interfaces;
using Tarefas.Application.ViewModels;

namespace Tarefas.Service.WebApi.Controllers
{
    public class TarefasController : BaseController
    {

        private readonly ITarefaAppService _tarefaAppService;

        public TarefasController(ITarefaAppService tarefaAppService)
        {
            _tarefaAppService = tarefaAppService;
        }

        [Route("minhas-tarefas")]
        [HttpGet]
        public IEnumerable<TarefaViewModel> Get()
        {
            return _tarefaAppService.BuscarTodos().Result;
        }

        [Route("detalhes-da-tarefa/{id:guid}")]
        [HttpGet]
        public TarefaViewModel Details(Guid? id)
        {
            return _tarefaAppService.BuscarPorId(id.Value).Result;
        }

        [HttpPost]
        [Route("nova-tarefa")]
        public IActionResult Post([FromBody]TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
                return Response();

            var sucesso = _tarefaAppService.Adicionar(tarefaViewModel);

            return Response(tarefaViewModel);
        }

        [HttpPut]
        [Route("editar-tarefa")]
        public IActionResult Put([FromBody]TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
                return Response();

            var sucesso = _tarefaAppService.Atualizar(tarefaViewModel);

            return Response(tarefaViewModel);
        }

        [HttpDelete]
        [Route("apagar-tarefa/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var tarefa = await _tarefaAppService.BuscarPorId(id.Value);
            if (tarefa == null)
                return NotFound();

            var sucesso = _tarefaAppService.Remover(tarefa);

            return Response(sucesso);
        }
    }
}