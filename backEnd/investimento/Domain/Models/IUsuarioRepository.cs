namespace investimento.Domain.Models
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<Usuario> Get();

        Usuario? GetUserByEmail(string email);

        Usuario? GetUserByEmailAndPassword(string email, string senha);
    }
}
