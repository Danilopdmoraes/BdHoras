using BdHoras.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BdHoras.Filters
{
    public class GestoresFilter : IAsyncActionFilter
    {
        private readonly IGestoresService _gestoresService;

        public GestoresFilter(IGestoresService gestoresService)
        {
            _gestoresService = gestoresService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                var idIdentity = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); // obtém o ID do Identity

                if (!string.IsNullOrEmpty(idIdentity))
                {
                    var gestor = await _gestoresService.ObterGestorPorIdExclusivoAsync(idIdentity); // envia o ID do Identity para comparação com o ID re
                    if(gestor != null)
                    {
                        controller.ViewData["IdGestor"] = gestor.IdGestor;
                        controller.ViewData["NomeGestor"] = gestor.NomeGestor;
                        controller.ViewData["EmailGestor"] = gestor.EmailGestor;
                        controller.ViewData["NomeGrupo"] = gestor.NomeGrupo;
                    }
                }
            }
            await next();
        }
    }
}
