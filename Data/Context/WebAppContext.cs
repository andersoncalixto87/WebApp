using Microsoft.EntityFrameworkCore;
using WebApp.Entities;

namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {

        public WebAppContext()
        {
            
        }
        public WebAppContext(DbContextOptions<WebAppContext> options ) : base(options){}
        
        public DbSet<Cliente> Clientes{get;set;}
        public DbSet<Produto> Produtos{get;set;}
        public DbSet<Usuario> Usuarios{get;set;}
        public DbSet<Venda> Vendas{get;set;}
        public DbSet<VendaItem> VendaItens{get;set;}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoConfiguration).Assembly);

            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            
        //}

    }
}