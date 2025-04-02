namespace investimento.Domain.Models
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();

        User? GetUserByEmail(string email);

        AuthResult GetUserByToken(string token);
    }
}
