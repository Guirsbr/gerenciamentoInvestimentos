using investimento.Application.ViewModel;

namespace investimento.Domain.Models.UserAggregate
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();

        User? GetUserByEmail(string email);

        AuthResultViewModel ValidateUser(string token);
    }
}
