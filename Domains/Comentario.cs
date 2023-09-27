using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Health_Clinic.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required]
        public DateTime DataHoraComentario { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Comentário Obrigatório")]
        public string? TextoComentario { get; set; }

        [Column(TypeName = "INT")]
        public int Avaliacao { get; set; }

        [Column(TypeName = "BIT")]
        public bool Respondido { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? DataResposta { get; set; }




        [Required(ErrorMessage = "Paciente Obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public virtual Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Consulta Obrigatório")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public virtual Consulta? Consulta { get; set; }

        [Required(ErrorMessage = "Médico Obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public virtual Medico? Medico { get; set; }
    }
}
