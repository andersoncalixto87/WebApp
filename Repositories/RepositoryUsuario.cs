using System.Linq;
using WebApp.Data;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class RepositoryUsuario : Repository<Usuario>, IRepositoryUsuario
    {
        private readonly WebAppContext _WebAppContext;
        public RepositoryUsuario(WebAppContext webAppContext) : base(webAppContext)
        {
             _WebAppContext = webAppContext;
        }

        public bool IsUsernameAvailable(string Username)
        {
            var usuario = _WebAppContext.Usuarios.Where(c => c.Username == Username).FirstOrDefault();
            if(usuario is null)
                return true;

            return false;
        }

        public bool IsEmailAvailable(string Email)
        {
            var usuario = _WebAppContext.Usuarios.Where(c => c.Email == Email).FirstOrDefault();
            if(usuario is null)
                return true;

            return false;
        }

        public Usuario Login(string UsernameOrEmail, string Password)
        {
            
            var usuario = new Usuario();
            if(UsernameOrEmail.Contains("@"))
                usuario = _webAppContext.Usuarios.Where(c => c.Email == UsernameOrEmail && c.Password == Password).FirstOrDefault();
            else
                usuario = _webAppContext.Usuarios.Where(c => c.Username == UsernameOrEmail && c.Password == Password).FirstOrDefault();
                
            
            return usuario;
        }
    }
}