using System.Security.Claims;
using System.Text.Json;
using BdHoras.Data;
using BdHoras.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace BdHoras.Services;

public class GestoresService : IGestoresService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GestoresService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<GestoresModel> ObterGestorPorIdExclusivoAsync(string idIdentity) // compara os IDs e retorna o ID Identity
    {
        return await _context.TB_Gestores.FirstOrDefaultAsync(g => g.IdExclusivo == idIdentity);
    }

    //public async Task<GestoresModel> ObterGestor(ActionExecutingContext identityContext) // compara os IDs e retorna o ID Identity
    //{
    //    var idIdentity = identityContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    //    return await _context.TB_Gestores.FirstOrDefaultAsync(g => g.IdExclusivo == idIdentity);
    //}



    public async Task<string?> ObterPossuiGrupoAsync(string userId)
    {
        var possuiGrupo = await _context.TB_Gestores
            .Where(g => g.IdExclusivo == userId)
            .Select(g => g.NomeGrupo)
            .FirstOrDefaultAsync();

        return possuiGrupo;
            
    }



    //public async Task CarregarGestorAsync()
    //{
    //    var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
    //    var gestor = await _context.TB_Gestores.FirstOrDefaultAsync(g => g.IdExclusivo == userId);
    //    var sessionData = JsonSerializer.Serialize(gestor);
    //    _httpContextAccessor.HttpContext.Session.SetString("GestorLogado", sessionData);
    //}

    //public GestoresModel? ObterGestorDaSessao()
    //{
    //    var sessionData = _httpContextAccessor.HttpContext.Session.GetString("GestorLogado");
    //    return string.IsNullOrEmpty(sessionData) ? null : JsonSerializer.Deserialize<GestoresModel>(sessionData);
    //}



}
