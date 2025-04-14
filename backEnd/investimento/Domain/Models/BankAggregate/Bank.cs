using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models.BankAggregate
{
    [Table("bank")]
    public class Bank
    {
        [Key]
        public int? id { get; private set; }
        public string name { get; private set; }

        public Bank(string name)
        {
            this.name = name;
        }
    }
}
