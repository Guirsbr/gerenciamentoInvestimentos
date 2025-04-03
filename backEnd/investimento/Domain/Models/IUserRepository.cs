using investimento.Application.ViewModel;

namespace investimento.Domain.Models
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();

        User? GetUserByEmail(string email);

        AuthResultViewModel GetUserByToken(string token);
    }
}
