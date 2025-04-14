namespace investimento.Domain.Models.BankAggregate
{
    public interface IBankRepository
    {
        void Add(Bank bank);

        List<Bank> Get();
    }
}
