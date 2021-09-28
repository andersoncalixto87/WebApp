using WebApp.Entities;

namespace WebApp.Interfaces.Services
{
    public interface IServiceEmail
    {
        bool EnviarEmail(EmailRemetente Email);
         
    }
}