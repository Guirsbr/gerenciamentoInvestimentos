using System.IdentityModel.Tokens.Jwt;
using System.Text;
using investimento.Application.ViewModel;
using investimento.Domain.Models.UserAggregate;
using investimento.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace investimento.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.email == email);
        }

        public AuthResultViewModel ValidateUser(string token)
        {
            if (!TokenHandlerHelper.ValidateToken(token))
            {
                return new AuthResultViewModel();
            }

            var userId = TokenHandlerHelper.GetUserIdFromToken(token);

            var databaseUser = _context.Users.FirstOrDefault(u => u.id == userId);
            if (databaseUser == null)
            {
                return new AuthResultViewModel();
            }

            return new AuthResultViewModel(token, true, databaseUser.name);
        }
    }
}
