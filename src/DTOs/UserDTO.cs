namespace sda_onsite_2_csharp_backend_teamwork.src.DTOs;
public class UserReadDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string CountryCode { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
}
public class UserCreateDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string CountryCode { get; set; }
    public string Phone { get; set; }
}
public class UserSignIn
{
    public string Email { get; set; }
    public string Password { get; set; }
}
public class UserUpdateDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string CountryCode { get; set; }
    public string Phone { get; set; }
}