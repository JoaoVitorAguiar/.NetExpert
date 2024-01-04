using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Models;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    // api/projetcs?query=net core
    [HttpGet]
    public IActionResult Get(string query)
    {
        return Ok();
    }

    // api/projects/3
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        // NotFound();
        return Ok(id);
    }

    [HttpPost]
    public IActionResult Post(
        [FromBody] CreateProjectModel createProjectModel)
    {
        if(createProjectModel.Title.Length > 50)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetById), new {id = createProjectModel.Id}, createProjectModel); // status 201
    }

    // api/project/2
    [HttpPut("{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] UpdateProjectModel updateProjectModel)
    {
        if(updateProjectModel.Description.Length > 200) 
        {
            return BadRequest();
        }
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
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
