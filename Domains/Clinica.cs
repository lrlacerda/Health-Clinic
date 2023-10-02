using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Health_Clinic.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? HorarioFuncionamento { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Razão Social obrigatório")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        [Required(ErrorMessage = "Telefone obrigatório")]
        public string? TelefoneClinica { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatório")]
        public string? EmailClinica { get; set; }
    }
}
