using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Nome" )]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }
        [Display(Name = "E-mail" )]
        [Required(ErrorMessage = "E-mail é obrigatório!")]
        public string Email { get; set; }
        [Display(Name = "Usuário" )]
        [Required(ErrorMessage = "Usuário é obrigatório!")]
        public string Username { get; set; }
        [Display(Name = "Senha" )]
        [Required(ErrorMessage = "Senha é obrigatória!")]
        [StringLength(16, ErrorMessage = "Deve ter entre 5 e 16 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirmar Senha" )]
        [Required(ErrorMessage = "Confirmação de Senha é obrigatória!")]
        [StringLength(16, ErrorMessage = "Deve ter entre 5 e 16 caracteres", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas não correspondem")]
        public string ConfirmPassword { get; set; }
        
    }
}