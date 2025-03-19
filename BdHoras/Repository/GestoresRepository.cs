using BdHoras.Data;
using BdHoras.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace BdHoras.Repository
{
    public class GestoresRepository : IGestoresRepository
    {
        private readonly ApplicationDbContext _context;

        public GestoresRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        // talvez isto aqui não seja necessário para Gestores, e sim para Funcionários:
        public List<GestoresModel> BuscarTodos()
        {
            return _context.TB_Gestores.ToList();
        }

        public GestoresModel Adicionar(GestoresModel gestor)
        {
            _context.TB_Gestores.Add(gestor);
            _context.SaveChanges();
            return gestor;
        }


        public GestoresModel ListarPorId(string userId)
        {
            return _context.TB_Gestores.FirstOrDefault(g => g.IdExclusivo == userId);
        }

        public GestoresModel Atualizar(GestoresModel gestorModel, string userId)
        {
            GestoresModel gestor = ListarPorId(userId);

            gestor.NomeGrupo = gestorModel.NomeGrupo;

            _context.TB_Gestores.Update(gestor);
            _context.SaveChanges();

            return gestor;
        }

    }
}
