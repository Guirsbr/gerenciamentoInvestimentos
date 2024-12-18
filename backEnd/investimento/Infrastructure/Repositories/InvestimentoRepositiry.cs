using investimento.Domain.Models;

namespace investimento.Infrastructure.Repositories
{
    public class InvestimentoRepositiry : IInvestimentoRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Investimento investimento)
        {
            _context.Investimentos.Add(investimento);
            _context.SaveChanges();
        }

        public List<Investimento> Get()
        {
            return _context.Investimentos.ToList();
        }
    }
}
