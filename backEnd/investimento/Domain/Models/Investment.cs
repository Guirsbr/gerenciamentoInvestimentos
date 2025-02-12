using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models
{
    [Table("investment")]
    public class Investment
    {
        [Key]
        public int? id { get; private set; }
        [Required]
        public double initial_value { get; private set; }
        [Required]
        public double current_value { get; private set; }
        [Required]
        public string rentability { get; private set; }
        [Required]
        public DateTime update_date { get; private set; }
        [Required]
        public DateTime registration_date { get; private set; }
        [Required]
        public int id__bank { get; private set; }
        [Required]
        public int id__investment_type { get; private set; }
        [Required]
        public int id__user { get; private set; }

        public Investment(
            double initial_value, double current_value, string rentability,
            int id__bank, int id__investment_type, int id__user)
        {
            this.initial_value = initial_value;
            this.current_value = current_value;
            this.rentability = rentability;
            update_date = DateTime.UtcNow;
            registration_date = DateTime.UtcNow;
            this.id__bank = id__bank;
            this.id__investment_type = id__investment_type;
            this.id__user = id__user;
        }
    }
}
