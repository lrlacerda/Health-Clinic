using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do Paciente Obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Data de Nascimento Obrigatória")]
        public DateTime DataNascimento { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        public string? Endereco { get; set; }

        //[Column(TypeName = "VARCHAR(50)")]
        //public string? Cidade { get; set; }

        //[Column(TypeName = "VARCHAR(20)")]
        //public string? Estado { get; set; }

        //[Column(TypeName = "VARCHAR(10)")]
        //public string? CEP { get; set; }




        [Required(ErrorMessage = "Usuário Obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public virtual Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Genero Obrigatório")]
        public Guid IdGenero { get; set; }

        [ForeignKey(nameof(IdGenero))]
        public virtual Genero? Genero { get; set; }
    }
}
