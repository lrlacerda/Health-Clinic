using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        public string? DescricaoConsulta { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DataCriacao { get; set; }




        [Required(ErrorMessage = "Médico Obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public virtual Medico? Medico { get; set; }

        [Required(ErrorMessage = "Paciente Obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public virtual Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Agendamento Obrigatório")]
        public Guid IdAgendamento { get; set; }

        [ForeignKey(nameof(IdAgendamento))]
        public virtual Agendamento? Agendamento { get; set; }

        [Required(ErrorMessage = "Prontuário Obrigatório")]
        public Guid IdProntuario { get; set; }

        [ForeignKey(nameof(IdProntuario))]
        public virtual Prontuario? Prontuario { get; set; }
    }
}
