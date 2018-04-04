using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tarefas.Service.WebApi.Controllers
{
    [Produces("application/json")]
    public class BaseController : Controller
    {
        protected new IActionResult Response(object result = null)
        {
            if (result != null)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = "Erro ao executar a operação"
            });
        }
    }
}