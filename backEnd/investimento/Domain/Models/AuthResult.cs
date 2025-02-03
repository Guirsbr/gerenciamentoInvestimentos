using System.ComponentModel.DataAnnotations;

namespace investimento.Domain.Models
{
    public class AuthResult
    {
        [Required]
        public string token { get; set; }
        [Required]
        public bool result { get; set; }
        [Required]
        public string nome { get; set; }

        public AuthResult(string token, bool result, string nome)
        {
            this.token = token;
            this.result = result;
            this.nome = nome;
        }

    }
}
