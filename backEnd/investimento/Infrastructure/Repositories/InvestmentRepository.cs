using System.IdentityModel.Tokens.Jwt;
using investimento.Application.ViewModel;
using investimento.Domain.Models.InvestmentAggregate;
using investimento.Domain.Models.UserAggregate;
using investimento.Helpers;
using Microsoft.EntityFrameworkCore;

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

        public List<InvestmentResponseViewModel> GetUserInvestments(string token)
        {
            if (!TokenHandlerHelper.ValidateToken(token))
            {
                return new List<InvestmentResponseViewModel>();
            }

            var userId = TokenHandlerHelper.GetUserIdFromToken(token);

            var investments = _context
            .Set<InvestmentResponseViewModel>()
            .FromSqlInterpolated($@"
                SELECT i.id, i.initial_value, i.current_value, i.rentability, i.update_date, 
                       i.registration_date, b.name AS bank_name, it.name AS investment_type_name
                FROM investment AS i
                JOIN bank AS b ON i.id__bank = b.id
                JOIN investment_type AS it ON i.id__investment_type = it.id
                WHERE i.id__user = {userId}
            ").AsNoTracking().ToList();

            return investments;
        }

        public Boolean DeleteUserInvestment(int investmentId, string token)
        {
            if (!TokenHandlerHelper.ValidateToken(token))
            {
                return false;
            }

            var userId = TokenHandlerHelper.GetUserIdFromToken(token);
            var investment = _context.Investments.FirstOrDefault(u => u.id == investmentId);

            if (investment == null || investment.id__user != userId)
            {
                return false;
            }

            _context.Investments.Remove(investment);
            _context.SaveChanges();
            return true;
        }
    }
}
