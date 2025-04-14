namespace investimento.Domain.Models.InvestmentTypeAggregate
{
    public interface IInvestmentTypeRepository
    {
        void Add(InvestmentType investmentType);

        List<InvestmentType> Get();
    }
}
