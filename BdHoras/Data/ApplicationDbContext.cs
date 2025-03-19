using BdHoras.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BdHoras.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // adicionados manualmente:
    public DbSet<GestoresModel> TB_Gestores { get; set; }
    public DbSet<FuncionariosModel> TB_Funcionarios { get; set; }
    public DbSet<VinculosModel> TB_Vinculos { get; set; }
    public DbSet<OcorrenciasModel> TB_Ocorrencias { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    ModelBuilder.Entity<FuncionariosModel>()
    //        .HasOne(f => f.Gestor)
    //        .WithMany(g => g.Funcionarios)
    //        .HasForeignKey(f => f.IdGestor)
    //        .OnDelete(DeleteBehavior.SetNull);
    //}

}
