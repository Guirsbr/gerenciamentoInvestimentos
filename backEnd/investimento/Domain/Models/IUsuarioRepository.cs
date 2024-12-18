namespace investimento.Domain.Models
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<Usuario> Get();
    }
}
