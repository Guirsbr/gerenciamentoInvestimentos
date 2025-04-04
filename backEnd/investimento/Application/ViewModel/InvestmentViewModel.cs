namespace investimento.Application.ViewModel
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public class InvestmentCreateViewModel
    {
        [Required]
        [Range(0.01, double.MaxValue)]
        public double initial_value { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public double current_value { get; set; }

        [Required]
        [StringLength(10)]
        public string rentability { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int id__bank { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int id__investment_type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int id__user { get; set; }
    }

    [Keyless]
    public class InvestmentResponseViewModel
    {
        public int id { get; set; }
        public double initial_value { get; set; }
        public double current_value { get; set; }
        public string rentability { get; set; }
        public DateTime update_date { get; set; }
        public DateTime registration_date { get; set; }
        public string bank_name { get; set; }
        public string investment_type_name { get; set; }
    }
}
