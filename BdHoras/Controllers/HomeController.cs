using System.Diagnostics;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Microsoft.AspNetCore.Authorization;

namespace BdHoras.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    public IActionResult Index()
    {
        //var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //if (user == null)
        //{
        //    return Challenge(); // redireciona para login
        //}
        //var gestorLogado = _context.TB_Gestores.FirstOrDefault(g => g.IdExclusivo == user);
        //var gestorLogado = _gestoresService.ObterGestorLogado();
        //return View(gestorLogado);

        return View();
    }

}