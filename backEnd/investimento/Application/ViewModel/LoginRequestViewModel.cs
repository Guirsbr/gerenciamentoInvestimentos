using System.ComponentModel.DataAnnotations;

namespace investimento.Application.ViewModel
{
    public class LoginRequestViewModel
    {
        [Required]
        public string email { get; init; }
        [Required]
        public string password { get; init; }
    }
}
