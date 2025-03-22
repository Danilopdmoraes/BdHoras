using BdHoras.Data;
using BdHoras.Models;
using BdHoras.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BdHoras.Controllers
{
    public class VinculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VinculosController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = new GestoresFuncionariosVinculosViewModel
            {
                Gestores = _context.TB_Gestores.ToList(),
                Funcionarios = _context.TB_Funcionarios.ToList(),
                Vinculo = new Models.VinculosModel()
            };

            return View(viewModel);
        }





        [HttpPost]
        public IActionResult GravarGrupo([FromBody] List<VinculosModel> grupoSelecionado)
        {
            if (grupoSelecionado != null)
            {
                _context.TB_Vinculos.AddRange(grupoSelecionado);
                _context.SaveChanges();
            }
            return Ok();
        }


    }
}
