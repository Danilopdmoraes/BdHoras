using Microsoft.AspNetCore.Mvc;

namespace BdHoras.Controllers
{
    public class FuncionariosController : Controller
    {
        public IActionResult CadastroFuncionarios()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
