using WebApp.Data;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class RepositoryProduto: Repository<Produto>, IRepositoryProduto
    {
        private readonly WebAppContext _WebAppContext;
        public RepositoryProduto(WebAppContext webAppContext) : base(webAppContext)
        {
            _WebAppContext = webAppContext;
            
        }
    }
}