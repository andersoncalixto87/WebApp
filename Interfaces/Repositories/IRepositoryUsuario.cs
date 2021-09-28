using WebApp.Entities;

namespace WebApp.Interfaces
{
    public interface IRepositoryUsuario : IRepository<Usuario>
    {
        Usuario Login(string Username, string Password);
        bool IsUsernameAvailable(string Username);
        bool IsEmailAvailable(string Email);
    }
}