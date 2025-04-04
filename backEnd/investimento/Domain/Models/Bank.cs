using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models
{
    [Table("bank")]
    public class Bank
    {
        public int? id { get; private set; }
        public string name { get; private set; }

        public Bank(string name)
        {
            this.name = name;
        }
    }
}
