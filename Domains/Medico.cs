using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")] 
        [Required(ErrorMessage = "Nome do Médico Obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(6)")]
        [Required(ErrorMessage = "CRM Obrigatório")]
        public int CRM { get; set; }

        [Column(TypeName = "VARCHAR(20)")] 
        public string? Telefone { get; set; }




        [Required(ErrorMessage = "Clinica Obrigatório")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public virtual Clinica? Clinica { get; set; }

        [Required(ErrorMessage = "Usuário Obrigatório")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public virtual Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Especialidade Obrigatório")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public virtual Especialidade? Especialidade { get; set; }
    }
}
