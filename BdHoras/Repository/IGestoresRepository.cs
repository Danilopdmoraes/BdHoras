using BdHoras.Models;

namespace BdHoras.Repository
{
    public interface IGestoresRepository
    {


        List<GestoresModel> BuscarTodos();
        GestoresModel Adicionar(GestoresModel gestor);

        GestoresModel ListarPorId(string userId);

        GestoresModel Atualizar(GestoresModel gestor, string userId);
    }
}
