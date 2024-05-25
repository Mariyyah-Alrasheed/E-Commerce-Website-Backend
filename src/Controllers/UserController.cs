using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers;

public class UserController : BaseController
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPatch("{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public UserReadDto? UpdateOne(string email, [FromBody] UserUpdateDto user)
    {
        return _userService.UpdateOne(email, user);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public List<UserReadDto> FindAll()
    {
        return _userService.FindAll();
    }

    [HttpGet("{email}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<UserReadDto?> FindOne(string email)
    {
        return Ok(_userService.FindOneByEmail(email));
    }

    [HttpPost("signup")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<UserReadDto> SignUp([FromBody] UserCreateDto user)
    {
        if (user is not null)
        {
            var createdUser = _userService.SignUp(user);
            if (createdUser is null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(SignUp), createdUser);
        }
        return BadRequest();
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<string> SignIn([FromBody] UserSignIn user)
    {
        if (user is not null)
        {
            string token = _userService.SignIn(user);
            if (token is null)
            {
                return BadRequest();
            }
            return Ok(token);
        }
        return BadRequest();
    }

    [HttpDelete("{email}")]
    // [Authorize(Roles = "Admin")]

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteOneByEmail(string email)
    {
        var result = _userService.DeleteOneByEmail(email);
        if (result)
        {
            return NoContent();
        }
        return NotFound();

    }


}