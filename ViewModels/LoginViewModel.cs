using System.ComponentModel.DataAnnotations;

namespace Health_Clinic_API_Lucas.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Endereço de Email")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um {0} válido")]
        public string? Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "A {0} deve conter pelo menos 6 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", ErrorMessage = "A {0} deve conter pelo menos uma letra minúscula, uma letra maiúscula, um número e um caractere especial")]
        public string? Senha { get; set; }
    }
}
