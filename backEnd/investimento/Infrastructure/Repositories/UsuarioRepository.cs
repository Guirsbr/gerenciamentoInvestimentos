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

        public List<Usuario> GetUserByEmail(string email)
        {
            var usuario = _context.Usuarios.FromSql($"SELECT * FROM usuario WHERE email={email}").ToList();
            return usuario;
        }

        public List<Usuario> GetUserByEmailAndPassword(string email, string senha)
        {
            var usuario = _context.Usuarios.FromSql($"SELECT * FROM usuario WHERE email={email} AND senha={senha}").ToList();
            return usuario;
        }
    }
}
