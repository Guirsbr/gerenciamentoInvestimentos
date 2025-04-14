using investimento.Domain.Models.BankAggregate;

namespace investimento.Infrastructure.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Bank bank)
        {
            _context.Banks.Add(bank);
            _context.SaveChanges();
        }

        public List<Bank> Get()
        {
            return _context.Banks.ToList();
        }
    }
}
