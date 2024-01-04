using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Models;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    // api/users/1
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    //api/user
    [HttpPost]
    public IActionResult Register(
        [FromBody] CreateUserModel createUserModel)
    {
        return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
    }

    // api/users/1/login
    [HttpPut("{id:int}/login")]
    public IActionResult Login(int id, LoginModel loginModel)
    {
        return NoContent();
    }
}
