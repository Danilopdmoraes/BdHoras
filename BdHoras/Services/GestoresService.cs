using BdHoras.Data;
using BdHoras.Models;
using Microsoft.EntityFrameworkCore;

namespace BdHoras.Services;

public class GestoresService : IGestoresService
{
    private readonly ApplicationDbContext _context;

    public GestoresService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<GestoresModel> ObterGestorPorIdExclusivoAsync(string idExclusivo) // compara os IDs e retorna o ID Identity
    {
        return await _context.TB_Gestores.FirstOrDefaultAsync(g => g.IdExclusivo == idExclusivo);
    }


}
