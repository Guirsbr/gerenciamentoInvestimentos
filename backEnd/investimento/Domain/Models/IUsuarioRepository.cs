namespace investimento.Domain.Models
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        List<Usuario> Get();

        List<Usuario> GetUserByEmail(string email);

        List<Usuario> GetUserByEmailAndPassword(string email, string senha);
    }
}
