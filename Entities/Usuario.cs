using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Entities
{
     [Table("tbUsuario")]
    public class Usuario : Base
    {
        [MaxLength(200)]
        [DataType(DataType.Text)]
        public string Nome { get; set; }
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string Username { get; set; }
    }
}