using BdHoras.Data;
using BdHoras.Models;
using BdHoras.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BdHoras.Controllers
{
    public class GestoresController : Controller
    {
        private readonly IGestoresRepository _gestorRepository;
        private readonly ApplicationDbContext _context;

        public GestoresController(IGestoresRepository gestorRepository, ApplicationDbContext context)
        {
            _gestorRepository = gestorRepository;
            _context = context;
        }

        public IActionResult CadastroGestores() // NomearGrupo() // Editar()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var gestorLogado = _context.TB_Gestores.FirstOrDefault(g => g.IdExclusivo == userId);

            return View(gestorLogado);
            //return View();
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;
            return View();
        }

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

    }
}
