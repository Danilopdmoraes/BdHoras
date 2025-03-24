using BdHoras.Data;
using BdHoras.Models;
using BdHoras.Repository;
using BdHoras.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol.Core.Types;

namespace BdHoras.Controllers
{
    public class GestoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IGestoresRepository _gestoresRepository;
        private readonly IGestoresService _gestoresService;

        public GestoresController(IGestoresRepository gestoresRepository, ApplicationDbContext context, IGestoresService gestoresService)
        {
            _context = context;
            _gestoresRepository = gestoresRepository;
            _gestoresService = gestoresService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}


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
            _gestoresRepository.Adicionar(gestor);
            return RedirectToAction("MontarGrupoGestores");
        }

        [HttpPost]
        public IActionResult Alterar(GestoresModel gestor)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _gestoresRepository.Atualizar(gestor, userId);
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


        //public IEnumerable<FuncionariosModel> ObterFuncionariosPorGestor(int idGestor)
        //{
        //    return _gestoresRepository.ObterFuncionariosPorGestor(idGestor);
        //}

        public IActionResult Index()
        {
            //var gestor = _gestoresService.ObterGestor;
            //var funcionarios = ObterFuncionariosPorGestor(idGestor);
            //return View(funcionarios);

            //_gestoresService.CarregarGestorAsync();

            //var gestor = _gestoresService.ObterGestorDaSessao();
            //ViewData["Gestor"] = gestor;

            return View();
        }

        //public async Task<IActionResult> Dashboard()
        //{
        //    await _gestoresService.CarregarGestorAsync();

        //    var gestor = _gestoresService.ObterGestorDaSessao();
        //    ViewData["Gestor"] = gestor;

        //    return View();
        //}

    }
}
