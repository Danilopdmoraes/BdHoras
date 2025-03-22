using BdHoras.Data;
using BdHoras.Models;
using BdHoras.Repository;
using BdHoras.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BdHoras.Controllers
{
    public class GestoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGestoresRepository _gestorRepository;
        private readonly IGestoresService _gestoresService;

        public GestoresController(IGestoresRepository gestorRepository, ApplicationDbContext context, IGestoresService gestoresService)
        {
            _context = context;
            _gestorRepository = gestorRepository;
            _gestoresService = gestoresService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        public IActionResult CadastroGestores() // NomearGrupo() // Editar()
        {
            return View();
        }


        [Authorize]
        public IActionResult MontarGrupoGestores()
        {
            return View();
        }

        public IActionResult EditarGrupoGestores()
        {
            return View();
        }

        public IActionResult DetalhesFuncionario()
        {
            return View();
        }

        public IActionResult NovoApontamento()
        {
            return View();
        }

        public IActionResult ConfirmarExcluirGrupo()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(GestoresModel gestor) 
        {
            _gestorRepository.Adicionar(gestor);
            return RedirectToAction("MontarGrupoGestores");
        }

        [HttpPost]
        public IActionResult Alterar(GestoresModel gestor)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _gestorRepository.Atualizar(gestor, userId);
            return RedirectToAction("MontarGrupoGestores");
        }


        public JsonResult BuscarFuncionarios(string termo) // BuscarFuncionario
        {
            var funcionarios = _context.TB_Funcionarios
                .Where(f => f.MatriculaFuncionario.ToString().Contains(termo) || f.NomeFuncionario.Contains(termo) || f.EmailFuncionario.Contains(termo))
                .Select(f => new { f.IdFuncionario, f.MatriculaFuncionario, f.NomeFuncionario, f.EmailFuncionario })
                .ToList();
            return Json(funcionarios);
        }

    }
}
