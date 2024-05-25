using Microsoft.EntityFrameworkCore;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.Databases;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Repositories;

public class UserRepository : IUserRepository
{
    private DbSet<User> _users;
    private DatabaseContext _databaseContext;
    public UserRepository(DatabaseContext databaseContext)
    {
        _users = databaseContext.User;
        _databaseContext = databaseContext;
    }
    public IEnumerable<User> FindAll()
    {
        return _users;
    }
    public User CreateOne(User user)
    {
        _users.Add(user);
        _databaseContext.SaveChanges();
        return user;
    }
    public User? FindOneByEmail(string email)
    {
        User? user = _users.FirstOrDefault(user => user.Email == email);
        return user;
    }
    public User UpdateOne(User updateUser)
    {
        return updateUser;
    }


    public bool DeleteOneByEmail(string email)
    {
        User? user = FindOneByEmail(email);
        if (user is null)
        {
            return false;
        }
        else
        {
            _users.Remove(user);
            _databaseContext.SaveChanges();
            return true;
        }
    }

}