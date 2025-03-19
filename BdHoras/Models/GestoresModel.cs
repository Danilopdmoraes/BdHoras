using System.ComponentModel.DataAnnotations;

namespace BdHoras.Models
{
    public class GestoresModel
    {
        [Key]
        public int IdGestor { get; set; }

        public string? IdExclusivo { get; set; }


        [Required]
        public string NomeGestor { get; set; }

        [Required, EmailAddress]
        public string EmailGestor { get; set; }


        public string NomeGrupo { get; set; }


        public virtual ICollection<VinculosModel> Vinculos { get; set; }

    }
}
