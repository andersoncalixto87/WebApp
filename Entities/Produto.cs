using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{
    [Table("tbProduto")]
    public class Produto : Base
    {
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Descricao { get; set; }
       
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        public bool IsDisponivel { get; set; }
       
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; }
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Foto { get; set; }
    }
}