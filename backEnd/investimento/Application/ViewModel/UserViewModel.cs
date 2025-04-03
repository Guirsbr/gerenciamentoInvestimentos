using System.ComponentModel.DataAnnotations;

namespace investimento.Application.ViewModel
{
    public class UserCreateViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6)]
        public string password { get; set; }
    }
}
