namespace investimento.Models
{
    public interface IInvestimentoRepository
    {
        void Add(Investimento investimento);

        List<Investimento> Get();
    }
}
