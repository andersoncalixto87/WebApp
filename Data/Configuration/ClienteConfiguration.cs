using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Entities;

namespace WebApp.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tbCliente");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(s => s.Nome).HasColumnName("Nome").HasColumnType("varchar(200)").IsRequired();
            builder.Property(s => s.Email).HasColumnName("Email").HasColumnType("varchar(200)").IsRequired();
            builder.Property(s => s.DataNasc).HasColumnName("DataNasc").HasColumnType("Date").IsRequired(false);
            builder.Property(s => s.Endereco).HasColumnName("Endereco").HasColumnType("varchar(400)").IsRequired(false);
            builder.Property(s => s.CPF).HasColumnName("CPF").HasColumnType("varchar(11)").IsRequired(false);
            builder.Property(s => s.Bairro).HasColumnName("Bairro").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(s => s.Cidade).HasColumnName("Cidade").HasColumnType("varchar(200)").IsRequired(false);
            builder.Property(s => s.Cep).HasColumnName("Cep").HasColumnType("varchar(8)").IsRequired(false);
            builder.Property(s => s.Estado).HasColumnName("Estado").HasColumnType("varchar(2)").IsRequired(false);
            builder.Property(s => s.IsAtivo).HasColumnName("IsAtivo").HasColumnType("bit").IsRequired(false);
            builder.Property(s => s.DataCadastro).HasColumnName("DataCadastro").HasColumnType("datetime").IsRequired(false);
        }
    }
}