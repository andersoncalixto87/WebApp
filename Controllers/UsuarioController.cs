using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApp.Entities;
using WebApp.Helper;
using WebApp.Interfaces;
using WebApp.Interfaces.Services;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IServiceEmail _serviceEmail;
        public UsuarioController(IRepositoryUsuario repositoryUsuario, IServiceEmail serviceEmail)
        {
            _repositoryUsuario = repositoryUsuario;
            _serviceEmail = serviceEmail;
        }
        public IActionResult Teste()
        {
            return View();
        }
        public IActionResult Log()
        {
            return View();
        }
        [HttpGet]        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Login(LoginViewModel loginViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            if(loginViewModel is null)
            {
                return NotFound();
            }
            var senhaMd5 = Helpers.GerarHashMd5(loginViewModel.Password);
            var usuario = _repositoryUsuario.Login(loginViewModel.UsernameOrEmail, senhaMd5);
            if(usuario is not null)
            {
                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Helpers.PrimeiroNome(usuario.Nome))
                };
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,props).Wait();
                
                
                return RedirectToAction("Dashboard","Home");
            }
            else    
                ModelState.AddModelError(string.Empty,"Usuário/E-mail ou senha Inválidos");    
            return View(loginViewModel);
        }

        public  async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Route("Usuario/NovaConta")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Usuario/NovaConta")]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            if(registerViewModel is null)
            {
                return NotFound();
            }
            
            if (!_repositoryUsuario.IsUsernameAvailable(registerViewModel.Username))
            {
                ModelState.AddModelError(string.Empty,"Usuário não disponivel");
                return View(registerViewModel);
            }

            if (!_repositoryUsuario.IsEmailAvailable(registerViewModel.Email))
            {
                ModelState.AddModelError(string.Empty,"E-mail não disponivel");
                return View(registerViewModel);
            }


            var senhaMd5 = Helpers.GerarHashMd5(registerViewModel.Password);
            registerViewModel.Password = senhaMd5;

            var usuario = new Usuario()
            {
                Email = registerViewModel.Email,
                Nome = registerViewModel.Nome,
                Username = registerViewModel.Username,
                Password = registerViewModel.Password
            };

            _repositoryUsuario.Add(usuario);
            TempData["Referrer"] = "SaveRegister";
            return View();
        }
        [HttpGet]
        [Route("Usuario/EsqueciSenha")]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [Route("Usuario/EsqueciSenha")]
        public  IActionResult ResetPassword(LoginViewModel loginViewModel) 
        {
            if(loginViewModel is null)
            {
                return NotFound();
            }
            EmailRemetente emailRemetente = new EmailRemetente();
            emailRemetente.Email = "anderson_calixto@hotmail.com";
            emailRemetente.Assunto = "Recuperação de senha";
            emailRemetente.Nome = "Anderson Calixto";
            emailRemetente.Mensagem = "Recuperação de senha";
            _serviceEmail.EnviarEmail(emailRemetente);
            return View(loginViewModel);
        }
    }
}