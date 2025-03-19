using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BdHoras.Models
{
    public class OcorrenciasModel
    {
        [Key]
        public int IdOcorrencia { get; set; }


        [ForeignKey("Gestor")]
        public int IdGestor { get; set; }
        public virtual GestoresModel Gestor { get; set; }



        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public virtual FuncionariosModel Funcionario { get; set; }



        public DateTime DataOcorrencia { get; set; }

        public int QtdHorasOcorrencia { get; set; }


        [Required]
        public string TipoOcorrencia { get; set; }

        [Required]
        public string Observacao { get; set; }
    }
}
