using System.ComponentModel.DataAnnotations.Schema;

namespace investimento.Domain.Models
{
    [Table("investment_type")]
    public class InvestmentType
    {
        public int? id { get; private set; }
        public string name { get; private set; }

        public InvestmentType(string name)
        {
            this.name = name;
        }
    }
}
