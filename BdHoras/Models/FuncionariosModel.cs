using System.ComponentModel.DataAnnotations;

namespace BdHoras.Models
{
    public class FuncionariosModel
    {
        [Key]
        public int IdFuncionario { get; set; }

        public string? IdExclusivo { get; set; }

        [Required]
        public int MatriculaFuncionario { get; set; } 

        [Required]
        public string NomeFuncionario { get; set; }

        [Required, EmailAddress]
        public string EmailFuncionario { get; set; }


        public virtual VinculosModel Vinculo { get; set; }
        public virtual ICollection<OcorrenciasModel> Ocorrencias { get; set; }

    }
}
