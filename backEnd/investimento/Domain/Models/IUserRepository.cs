namespace investimento.Domain.Models
{
    public interface IUserRepository
    {
        void Add(User user);

        List<User> Get();

        User? GetUserByEmail(string email);

        User? GetUserByEmailAndPassword(string email, string password);
    }
}
