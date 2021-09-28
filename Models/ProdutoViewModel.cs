using System;
using Microsoft.AspNetCore.Http;

namespace WebApp.Models
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public IFormFile Foto { get; set; }
        public string NomeFoto { get; set; }
    }
}