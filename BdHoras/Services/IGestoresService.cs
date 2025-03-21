using BdHoras.Models;

namespace BdHoras.Services
{
    public interface IGestoresService
    {
        Task<GestoresModel> ObterGestorPorIdExclusivoAsync(string idExclusivo);
    }
}
