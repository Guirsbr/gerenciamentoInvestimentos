using investimento.Domain.Models;

namespace investimento.Infrastructure.Repositories
{
    public class UsuarioRepositiry : IUsuarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }
    }
}
