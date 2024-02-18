using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistense;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;
    public ProjectService(DevFreelaDbContext devFreelaDbContext)
    {
        _dbContext = devFreelaDbContext;
    }
    public int Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost) ;
        _dbContext.Projects.Add(project);
        return project.Id; 
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.ClientId, inputModel.ProjectId);
    }

    public void Delete(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        project?.Cancel();

    }

    public void Finish(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        project?.Finish();
    }

    public List<ProjectViewModel> GetAll(string query)
    {
        var projects =  _dbContext.Projects;
        var projectsViewModel = projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToList();
        return projectsViewModel;
    }

    public ProjectDetailsViewModel? GetById(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        if (project == null) return null;
        return new ProjectDetailsViewModel(
            project.Id, 
            project.Title, 
            project.Description, 
            project.TotalCost, 
            project.StartedAt, 
            project.FinishedAt);
    }

    public void Start(int id)
    {
        var project = _dbContext.Projects.FirstOrDefault(p => p.Id == id);
        project?.Start();
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var project = _dbContext.Projects.FirstOrDefault(p => p.Id == inputModel.Id);
        project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
    }
}
