namespace investimento.Application.ViewModel
{
    using System.ComponentModel.DataAnnotations;

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
}
