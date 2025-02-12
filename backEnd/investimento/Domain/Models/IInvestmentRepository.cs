namespace investimento.Domain.Models
{
    public interface IInvestmentRepository
    {
        void Add(Investment investment);

        List<Investment> Get();
    }
}
