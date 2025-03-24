using BdHoras.Models;

namespace BdHoras.Repository
{
    public interface IGestoresRepository
    {


        List<GestoresModel> BuscarTodos();
        GestoresModel Adicionar(GestoresModel gestor);

        GestoresModel ListarPorId(string userId);

        GestoresModel Atualizar(GestoresModel gestor, string userId);

        //IEnumerable<FuncionariosModel> ObterFuncionariosPorGestor(int idGestor); // apresenta os funcionários do grupo do gestor 
        //IEnumerable<FuncionariosModel> ObterFuncionariosPorGestor(); // apresenta os funcionários do grupo do gestor 
    }
}
