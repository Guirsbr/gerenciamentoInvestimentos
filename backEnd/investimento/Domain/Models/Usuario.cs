using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; private set; }
        [Required]
        public string nome { get; private set; }
        [Required]
        public string email { get; private set; }
        [Required]
        public string senha { get; private set; }
        [Required]
        public DateTime data_cadastro { get; private set; }

        public Usuario(string nome, string email, string senha)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.data_cadastro = DateTime.UtcNow;
        }

        public Usuario(string nome)
        {
            this.nome = nome;
        }
    }
}
