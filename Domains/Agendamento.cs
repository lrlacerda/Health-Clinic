using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Agendamento))]
    public class Agendamento
    {
        [Key]
        public Guid IdAgendamento { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string? StatusAgendamento { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data e Hora obrigatórios")]
        public DateTime DataHoraConsulta { get; set; }





        [Required(ErrorMessage = "Paciente Obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public virtual Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Médico Obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public virtual Medico? Medico { get; set; }
    }
}
