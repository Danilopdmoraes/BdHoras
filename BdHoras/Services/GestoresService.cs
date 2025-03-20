using BdHoras.Data;
using BdHoras.Models;
using System.Security.Claims;

namespace BdHoras.Services;

public class GestoresService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GestoresService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public GestoresModel ObterGestorLogado()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return null;
        }

        return _context.TB_Gestores.FirstOrDefault(g => g.IdExclusivo == userId);
    }
}
