using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models.InvestmentTypeAggregate
{
    [Table("investment_type")]
    public class InvestmentType
    {
        [Key]
        public int? id { get; private set; }
        public string name { get; private set; }

        public InvestmentType(string name)
        {
            this.name = name;
        }
    }
}
