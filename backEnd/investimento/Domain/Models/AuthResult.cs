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
        public string name { get; set; }

        public AuthResult(string token, bool result, string name)
        {
            this.token = token;
            this.result = result;
            this.name = name;
        }

    }
}
