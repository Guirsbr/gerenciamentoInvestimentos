using investimento.Domain.Models;

namespace investimento.Infrastructure.Repositories
{
    public class InvestmentTypeRepository : IInvestmentTypeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(InvestmentType investmentType)
        {
            _context.InvestmentTypes.Add(investmentType);
            _context.SaveChanges();
        }

        public List<InvestmentType> Get()
        {
            return _context.InvestmentTypes.ToList();
        }
    }
}
