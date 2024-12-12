using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using investimento.Infraestrutura;

namespace investimento.Models
{
    [Table("investimento")]
    public class Investimento
    {
        [Key]
        public int id {  get; private set; }
        [Required]
        public string rentabilidade { get; private set; }
        public DateTime data { get; private set; }

        public Investimento(string rentabilidade)
        {
            this.rentabilidade = rentabilidade;
            data = DateTime.UtcNow;
        }
    }
}
