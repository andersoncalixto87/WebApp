using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{   
    [Table("tbCliente")]
    public class Cliente :Base
    {
        
        public Cliente()
        {
            IsAtivo = true;
            DataCadastro = DateTime.Now;
        }
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNasc  { get; set; }
        [MaxLength(11)]
        [DataType(DataType.Text)]
        public string CPF { get; set; }
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        [MaxLength(400)]
        [DataType(DataType.Text)]
        public string Endereco { get; set; }
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Bairro { get; set; }
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Cidade { get; set; }
        [MaxLength(8)]
        [DataType(DataType.Text)]
        public string  Cep { get; set; }
        [MaxLength(2)]
        [DataType(DataType.Text)]
        public string Estado { get; set; }
        public bool IsAtivo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { get; set; }
        [MaxLength(1)]
        [DataType(DataType.Text)]
        public string Sexo { get; set; }
    }
}