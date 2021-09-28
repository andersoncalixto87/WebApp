using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{
    [Table("tbVendaItem")]
    public class VendaItem : Base
    {
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}