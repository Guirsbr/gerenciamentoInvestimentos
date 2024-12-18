namespace investimento.Domain.Models
{
    public interface IInvestimentoRepository
    {
        void Add(Investimento investimento);

        List<Investimento> Get();
    }
}
