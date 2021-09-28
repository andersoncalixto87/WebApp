using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Data.Configuration
{
    public class ProdutoConfiguration: IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tbProduto");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(s => s.Descricao).HasColumnName("Descricao").HasColumnType("varchar(200)").IsRequired();
            builder.Property(s => s.Valor).HasColumnName("Valor").HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(s => s.IsDisponivel).HasColumnName("IsDisponivel").HasColumnType("bit").IsRequired(false);
            builder.Property(s => s.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired(false);
        }
        
    }
}