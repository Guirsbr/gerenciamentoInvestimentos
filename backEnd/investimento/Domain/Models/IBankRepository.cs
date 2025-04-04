namespace investimento.Domain.Models
{
    public interface IBankRepository
    {
        void Add(Bank bank);

        List<Bank> Get();
    }
}
