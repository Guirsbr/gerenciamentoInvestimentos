using System.ComponentModel.DataAnnotations;

namespace investimento.Domain.Models
{
    public class LoginRequest
    {
        [Required]
        public string email { get; init; }
        [Required]
        public string senha { get; init; }

        public LoginRequest(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }
    }
}
