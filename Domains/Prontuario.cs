using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        [Key]
        public Guid IdProntuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Histórico Obrigatório")]
        public string? HistoricoMedico { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Diagnóstico Obrigatório")]
        public string? DiagnosticoAtual { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Tratamento Obrigatório")]
        public string? Tratamento { get; set; }

        [Column(TypeName = "TEXT")]
        public string? Observacoes { get; set; }




        [Required(ErrorMessage = "Paciente Obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public virtual Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Médico Responsável Obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public virtual Medico? Medico { get; set; }
    }
}
