using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Health_Clinic.Domains
{
    [Table(nameof(Genero))]
    public class Genero
    {
        [Key]
        public Guid IDGenero { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(20)")] 
        [Required(ErrorMessage = "Nome do Gênero Obrigatório")]
        public string? NomeGenero { get; set; }
    }
}
