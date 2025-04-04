namespace investimento.Domain.Models
{
    public interface IInvestmentTypeRepository
    {
        void Add(InvestmentType investmentType);

        List<InvestmentType> Get();
    }
}
