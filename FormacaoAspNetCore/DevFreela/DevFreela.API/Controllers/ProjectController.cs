using DevFreela.API.Models;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Models;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // api/projetcs?query=net core
    [HttpGet]
    public async Task<IActionResult> Get(string query)
    {
        var projects = await _projectService.GetAll(query);
        return Ok(projects);
    }

    // api/projects/3
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var project =  await _projectService.GetById(id);
        if(project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] NewProjectInputModel inputModel)
    {
        if(inputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        var id = await _projectService.Create(inputModel);
        return CreatedAtAction(nameof(GetById), new { id }, inputModel); // status 201
    }

    // api/project/2
    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] UpdateProjectInputModel inputModel)
    {
        if (inputModel.Description.Length > 200)
        {
            return BadRequest();
        }
        _projectService.Update(inputModel);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _projectService.Delete(id);
        return NoContent();
    }

    // api/projects/1/comment
    [HttpPost("{id:int}/comments")]
    public IActionResult PostComments(
        int id,
        [FromBody] CreateCommentModel createCommentModel)
    {
        return NoContent();
    }
    // api/projects/1/start
    [HttpPost("{id:int}/start")]
    public IActionResult Start(
        int id)
    {
        return NoContent();
    }

    // api/projects/1/finish
    [HttpPost("{id:int}/finish")]
    public IActionResult Finish(int id)
    {
        return NoContent();
    }
}
