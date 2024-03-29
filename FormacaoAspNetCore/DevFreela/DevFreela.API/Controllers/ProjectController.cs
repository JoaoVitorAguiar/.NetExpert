
using DevFreela.API.Models;
using DevFreela.Application.Commands.Project.CreateProject;
using DevFreela.Application.Commands.Project.CreateComment;
using DevFreela.Application.Commands.Project.DeleteProject;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Application.Commands.Project.StartProject;
using DevFreela.Application.Commands.Project.FnishProject;
using DevFreela.Application.Commands.Project.UpdateProject;
using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Application.Queries.Projects.GetByIdProjects;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController( IMediator mediator)
    {
        _mediator = mediator;
    }

    // api/projetcs?query=net core
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var getAllProjectsQuery = new GetAllProjectsQuery(query);
        var projects = await _mediator.Send(getAllProjectsQuery);
        return Ok(projects);
    }

    // api/projects/3
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var getByIdQuery = new GetByIdProjectQuery(id);
        var query = await _mediator.Send(getByIdQuery);   
        return Ok(query);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] CreateProjectCommand command)
    {
        if(command.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, command); // status 201
    }

    // api/project/2
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(
        [FromRoute] int id,
        [FromBody] UpdateProjectCommand command)
    {
        if (command.Description.Length > 200)
        {
            return BadRequest();
        }
        var project = await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    // api/projects/1/comment
    [HttpPost("{id:int}/comments")]
    public async Task<IActionResult> PostComments(
        int id,
        [FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    // api/projects/1/start
    [HttpPost("{id:int}/start")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }

    // api/projects/1/finish
    [HttpPost("{id:int}/finish")]
    public async Task<IActionResult> Finish(int id)
    {
        var command = new FinishProjectCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}
