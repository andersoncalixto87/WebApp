using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginViewModel
    {  
        [Display(Name = "Senha" )]
        [Required(ErrorMessage="Senha é obrigatória!")]
        public string Password { get; set; }
        [Display(Name = "Usuário ou E-mail" )]
        [Required(ErrorMessage="Usuario/E-mail é obrigatório!")]
        public string UsernameOrEmail { get; set; }
        

    }
}