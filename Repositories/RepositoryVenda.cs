using WebApp.Data;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class RepositoryVenda : Repository<Venda>, IRepositoryVenda
    {
        private readonly WebAppContext _WebAppContext;
        public RepositoryVenda(WebAppContext webAppContext) : base(webAppContext)
        {
            _WebAppContext = webAppContext;
        }
    }
}