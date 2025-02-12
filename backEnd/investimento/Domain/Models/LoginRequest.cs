using System.ComponentModel.DataAnnotations;

namespace investimento.Domain.Models
{
    public class LoginRequest
    {
        [Required]
        public string email { get; init; }
        [Required]
        public string password { get; init; }

        public LoginRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
