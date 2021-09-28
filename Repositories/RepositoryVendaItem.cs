using WebApp.Data;
using WebApp.Entities;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class RepositoryVendaItem: Repository<VendaItem>, IRepositoryVendaItem
    {
        private readonly WebAppContext _WebAppContext;
        public RepositoryVendaItem(WebAppContext webAppContext) : base(webAppContext)
        {
            _WebAppContext = webAppContext;
        }
    }
}