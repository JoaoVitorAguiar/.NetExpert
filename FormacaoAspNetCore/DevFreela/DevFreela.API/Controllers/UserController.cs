using DevFreela.API.Models;
using DevFreela.Application.Commands.User.CreateUser;
using DevFreela.Application.Commands.User.Login;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userServices;
    private readonly IMediator _mediator;
    public UserController(IUserServices userServices, IMediator mediator)
    {
        _userServices = userServices;
        _mediator = mediator;
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
        [FromBody] CreateUserCommand command)
    {
        await _mediator.Send(command);
            
        return Created();
    }

    // api/users/1/login
    [HttpPut("/login")]
    public async Task<IActionResult> Login(
        [FromBody]LoginCommand command)
    {
        var loginUserViewModel = await _mediator.Send(command);   
        if(loginUserViewModel == null) 
        {
            return BadRequest();
        }
        return Ok(loginUserViewModel);
    }
}
