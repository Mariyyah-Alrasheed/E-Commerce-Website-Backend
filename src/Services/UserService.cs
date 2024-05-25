using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
using sda_onsite_2_csharp_backend_teamwork.src.Utils;
namespace sda_onsite_2_csharp_backend_teamwork.src.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IConfiguration _config;
    private IMapper _mapper;

    public UserService(IUserRepository userRepository, IConfiguration config, IMapper mapper)
    {
        _userRepository = userRepository;
        _config = config;
        _mapper = mapper;
    }

    public string SignIn(UserSignIn userSign)
    {
        User? user = _userRepository.FindOneByEmail(userSign.Email);
        if (user is null) return null;

        byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);

        bool isCorrectPass = PasswordUtils.VarifyPassword(userSign.Password, user.Password, pepper);

        if (!isCorrectPass) return null;

        var claims = new[]
             {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
             new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }

    public UserReadDto? SignUp(UserCreateDto user)
    {
        User? foundUser = _userRepository.FindOneByEmail(user.Email);
        if (foundUser is not null)
        {
            return null;
        }
        byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);

        PasswordUtils.HashPassword(user.Password, out string hashedPassword, pepper);

        user.Password = hashedPassword;
        User mappedUser = _mapper.Map<User>(user);

        var newUser = _userRepository.CreateOne(mappedUser);

        UserReadDto userRead = _mapper.Map<UserReadDto>(newUser);

        return userRead;
    }
    public List<UserReadDto> FindAll()
    {
        var users = _userRepository.FindAll();
        var userRead = users.Select(_mapper.Map<UserReadDto>);
        return userRead.ToList();
    }

    public UserReadDto? FindOneByEmail(string email)
    {
        var user = _userRepository.FindOneByEmail(email);
        UserReadDto? userRead = _mapper.Map<UserReadDto>(user);
        return userRead;
    }
    public UserReadDto? UpdateOne(string email, UserUpdateDto newValue)
    {
        User? user = _userRepository.FindOneByEmail(email);
        if (user is not null)
        {
            UserReadDto userRead = _mapper.Map<UserReadDto>(user);
            userRead.FullName = newValue.FullName;
            userRead.Phone = newValue.Phone;
            userRead.CountryCode = newValue.CountryCode;
            User userupdated = _mapper.Map<User>(userRead);

            var uee = _userRepository.UpdateOne(userupdated);
            var userupdat = _mapper.Map<UserReadDto>(uee);

            return userupdat;
        }
        return null;


    }

    public bool DeleteOneByEmail(string userEmail)
    {
        var result = _userRepository.DeleteOneByEmail(userEmail);

        if (result)
        {
            return true;
        }
        return false;
    }
}