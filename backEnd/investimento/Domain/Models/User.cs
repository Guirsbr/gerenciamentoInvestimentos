using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        public int? id { get; private set; }
        [Required]
        public string name { get; private set; }
        [Required]
        public string email { get; private set; }
        [Required]
        public string password { get; private set; }
        [Required]
        public DateTime registration_date { get; private set; }

        public User(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.registration_date = DateTime.UtcNow;
        }

        public User(int? id, string name, string email, string password, DateTime registration_date)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.registration_date = registration_date;
        }
    }
}
