using investimento.Domain.Models;

namespace investimento.Infrastructure.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Investment investment)
        {
            _context.Investments.Add(investment);
            _context.SaveChanges();
        }

        public List<Investment> Get()
        {
            return _context.Investments.ToList();
        }
    }
}
