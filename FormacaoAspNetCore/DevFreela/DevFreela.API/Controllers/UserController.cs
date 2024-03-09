using DevFreela.API.Models;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    public UserController (IUserServices userServices)
    { 
        _userServices = userServices;
    }

    // api/users/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var users = await _userServices.GetById(id);
        return Ok(users);
    }

    // api/user
    [HttpPost("")]
    public async Task<IActionResult> Register(
        [FromBody] UserRegisterInputModel inputModel)
    {

        var id = await _userServices.Register(inputModel);
        var user = new UserViewModel(
            id,
            inputModel.FisrtName,
            inputModel.LastName,
            inputModel.Email
            );
            
        return CreatedAtAction(nameof(GetById), new { id }, user);
    }

    // api/users/1/login
    [HttpPut("{id:int}/login")]
    public async Task<IActionResult> Login(int id, UserLoginInputModel inputModel)
    {
        var login = await _userServices.Login(inputModel);
        return NoContent();
    }
}
