using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;

namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions
{
    public interface IUserService
    {
        public List<UserReadDto> FindAll();
        public UserReadDto SignUp(UserCreateDto user);
        public string SignIn(UserSignIn user);
        public UserReadDto? FindOneByEmail(string email);
        public UserReadDto UpdateOne(string email, UserReadDto newValue);
    }
}