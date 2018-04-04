using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tarefas.Application.Interfaces;
using Tarefas.Application.ViewModels;

namespace Tarefas.UI.MVC.Controllers
{
    public class TarefasController : Controller
    {
        private readonly ITarefaAppService _tarefaAppService;

        public TarefasController(ITarefaAppService tarefaAppService)
        {
            _tarefaAppService = tarefaAppService;
        }

        [Route("")]
        [Route("minhas-tarefas")]
        public async Task<IActionResult> Index()
        {
            return View(await _tarefaAppService.BuscarTodos());
        }

        [Route("detalhes-da-tarefa/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var tarefa = await _tarefaAppService.BuscarPorId(id.Value);
            if (tarefa == null)
                return NotFound();

            return View(tarefa);
        }

        [Route("nova-tarefa")]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("nova-tarefa")]
        public IActionResult Create(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
                return View(tarefaViewModel);

            var sucesso = _tarefaAppService.Adicionar(tarefaViewModel);
            
            TempData["RetornoPost"] = sucesso ? $"success,Tarefa <b>{tarefaViewModel.Titulo}</b> criada com sucesso :)" : 
                $"error,Ocorreu um erro ao tentar criar a tarefa <b>{tarefaViewModel.Titulo}</b> :(";

            return RedirectToAction("Index");
        }

        [Route("editar-tarefa/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var tarefa = await _tarefaAppService.BuscarPorId(id.Value);
            if (tarefa == null)
                return NotFound();
                        
            return View(tarefa);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-tarefa/{id:guid}")]
        public IActionResult Edit(TarefaViewModel tarefaViewModel)
        {
            if (!ModelState.IsValid)
                return View(tarefaViewModel);

            var sucesso = _tarefaAppService.Atualizar(tarefaViewModel);

            TempData["RetornoPost"] = sucesso ? $"success,Tarefa <b>{tarefaViewModel.Titulo}</b> alterada com sucesso :)" :
                $"error,Ocorreu um erro ao tentar alterar a tarefa {tarefaViewModel.Titulo} :(";

            return RedirectToAction("Index");
        }

        [Route("apagar-tarefa/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var tarefa = await _tarefaAppService.BuscarPorId(id.Value);
            if (tarefa == null)
                return NotFound();
            
            return PartialView("_Delete", tarefa);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("apagar-tarefa/{id:guid}")]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (id == null)
                return NotFound();

            var tarefa = await _tarefaAppService.BuscarPorId(id.Value);
            if (tarefa == null)
                return NotFound();

            var sucesso = _tarefaAppService.Remover(tarefa);

            TempData["RetornoPost"] = sucesso ? $"success,Tarefa <b>{tarefa.Titulo}</b> excluída com sucesso :)" :
                $"error,Ocorreu um erro ao tentar excluir a tarefa <b>{tarefa.Titulo}</b> :(";

            return RedirectToAction("Index");
        }
    }
}