using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome Obrigatória")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")] 
        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")] 
        [Required(ErrorMessage = "Senha Obrigatória")]
        public string? Senha { get; set; }



        [Required(ErrorMessage = "Informe o Tipo do Usuário")]
        public Guid IdTiposUsuario { get; set; }

        public DateTime? DataRegistro { get; set; }

        [ForeignKey(nameof(IdTiposUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
