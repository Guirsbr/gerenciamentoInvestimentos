using System.ComponentModel.DataAnnotations;

namespace investimento.Application.ViewModel
{
    public class AuthResultViewModel
    {
        [Required]
        public string token { get; set; }
        [Required]
        public bool result { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string name { get; set; }

        public AuthResultViewModel(string token, bool result, string name)
        {
            this.token = token;
            this.result = result;
            this.name = name;
        }

        public AuthResultViewModel()
        {
            this.token = "";
            this.result = false;
            this.name = "";
        }

    }
}
