using WebApp.Data;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        private readonly WebAppContext _WebAppContext;
        public RepositoryCliente(WebAppContext webAppContext) : base(webAppContext)
        {
            _WebAppContext = webAppContext;
        }
    }
}