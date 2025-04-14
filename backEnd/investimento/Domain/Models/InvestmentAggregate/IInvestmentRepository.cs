using investimento.Application.ViewModel;

namespace investimento.Domain.Models.InvestmentAggregate
{
    public interface IInvestmentRepository
    {
        void Add(Investment investment);

        List<Investment> Get();

        public List<InvestmentResponseViewModel> GetUserInvestments(string token);
    }
}
