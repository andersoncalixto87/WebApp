using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{
     [Table("tbVenda")]
    public class Venda : Base
    {
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        [MaxLength(5000)]
        [DataType(DataType.Text)]
        public string Observacao { get; set; }
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}