using investimento.Application.ViewModel;

namespace investimento.Domain.Models.InvestmentAggregate
{
    public interface IInvestmentRepository
    {
        void Add(Investment investment);

        List<Investment> Get();

        List<InvestmentResponseViewModel> GetUserInvestments(string token);

        Boolean DeleteUserInvestment(int investmentId, string token);
    }
}
