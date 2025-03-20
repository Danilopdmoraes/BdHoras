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
        private readonly IGestoresRepository _gestorRepository;
        private readonly ApplicationDbContext _context;
        private readonly GestoresService _gestoresService;

        public GestoresController(IGestoresRepository gestorRepository, ApplicationDbContext context, GestoresService gestoresService)
        {
            _gestorRepository = gestorRepository;
            _context = context;
            _gestoresService = gestoresService;
        }

        [Authorize]
        public IActionResult CadastroGestores() // NomearGrupo() // Editar()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var gestorLogado = _context.TB_Gestores.FirstOrDefault(g => g.IdExclusivo == userId);

            //return View(gestorLogado);
            //return View();

            var gestorLogado = _gestoresService.ObterGestorLogado();
            return View(gestorLogado);
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;
            return View();
        }

        [Authorize]
        public IActionResult MontarGrupoGestores()
        {
            //var gestorLogado = _gestoresService.ObterGestorLogado();
            //return View(gestorLogado); // permite recuperar e exibir o nome do Grupo, que está em TB_Gestores

            string userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.UserId = userId;

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


        public JsonResult Buscar(string termo) // 'termo' é o que está sendo digitado lá no input
        {
            var funcionarios = _context.TB_Funcionarios
                .Where(f => f.MatriculaFuncionario.ToString().Contains(termo) || f.NomeFuncionario.Contains(termo) || f.EmailFuncionario.Contains(termo))
                .Select(f => new { f.IdFuncionario, f.MatriculaFuncionario, f.NomeFuncionario, f.EmailFuncionario })
                .ToList();
            return Json(funcionarios);
        }

    }
}
