using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BdHoras.Models;
using BdHoras.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Threading.Tasks;

namespace BdHoras.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context; // adicionado para buscar o Gestor logado
    private readonly UserManager<IdentityUser> _userManager; // adicionado para buscar o Gestor logado

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _context = context; // adicionado para buscar o Gestor logado
        _userManager = userManager; // adicionado para buscar o Gestor logado
    }

    public async Task<IActionResult> Index()
    {
        // o trecho abaixo quebra a aplicação se não estiver implementado corretamente
        // o usuário precisa logar antes
        // caso não esteja logado, é redirecionado para a tela de login automaticamente

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Challenge(); // redireciona para login
        }

        var gestorLogado = _context.TB_Gestores.FirstOrDefault(g => g.IdExclusivo == user.Id);

        return View(gestorLogado);
    }








    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}
