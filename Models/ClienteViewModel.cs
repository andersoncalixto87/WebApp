using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataNasc  { get; set; }
        public string CPF { get; set; }
         [Display(Name = "E-mail")]
        public string Email { get; set; }
        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string  Cep { get; set; }
        public string Estado { get; set; }
        public string Sexo { get; set; }
    }
}