using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions;

public interface IUserRepository
{
    public IEnumerable<User> FindAll();
    public User CreateOne(User user);
    public User? FindOneByEmail(string email);
    public User UpdateOne(User updateUser);
    public bool DeleteOneByEmail(string email);

}
