using BdHoras.Data;
using BdHoras.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using BdHoras.Services;

namespace BdHoras.Repository
{
    public class GestoresRepository : IGestoresRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly GestoresService _gestoresService;

        public GestoresRepository(ApplicationDbContext context, GestoresService gestoresService)
        {
            _context = context;
            _gestoresService = gestoresService;
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

        //public IEnumerable<FuncionariosModel> ObterFuncionariosPorGestor(int idGestor)
        //{
        //    return _context.TB_Vinculos
        //        .Where(v => v.IdGestor == idGestor)
        //        .Select(v => v.Funcionario)
        //        .ToList();
        //}

        //public IEnumerable<FuncionariosModel> ObterFuncionariosPorGestor()
        //{
        //    var gestorSessao = _gestoresService.ObterGestorDaSessao();
        //    return _context.TB_Vinculos
        //        .Where(v => v.IdGestor == gestorSessao.IdGestor)
        //        .Select(v => v.Funcionario)
        //        .ToList();
        //}

    }
}
