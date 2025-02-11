using investimento.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace investimento.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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

        public Usuario? GetUserByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.email == email);
        }

        public Usuario? GetUserByEmailAndPassword(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
        }
    }
}
