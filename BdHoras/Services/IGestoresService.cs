using BdHoras.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BdHoras.Services
{
    public interface IGestoresService
    {
        Task<GestoresModel> ObterGestorPorIdExclusivoAsync(string idExclusivo);

        Task<string?> ObterPossuiGrupoAsync(string userId);

        //Task<GestoresModel> ObterGestor(ActionExecutingContext identityContext);

        //Task CarregarGestorAsync();

        //GestoresModel? ObterGestorDaSessao();
    }
}
