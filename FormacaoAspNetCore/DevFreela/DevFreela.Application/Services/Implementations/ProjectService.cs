using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _dbContext;
    public ProjectService(DevFreelaDbContext devFreelaDbContext)
    {
        _dbContext = devFreelaDbContext;
    }
    public async Task<int> Create(NewProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost) ;
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
        return project.Id; 
    }

    public async void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.ClientId, inputModel.ProjectId);
        await _dbContext.ProjectComment.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async void Delete(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        if (project == null) return;
        project.Cancel();
        await _dbContext.SaveChangesAsync();
    }

    public async void Finish(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        project?.Finish();
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ProjectViewModel>> GetAll(string query)
    {
        var projects =  _dbContext.Projects;
        var projectsViewModel = await projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToListAsync();

        return projectsViewModel;
    }

    public async Task<ProjectDetailsViewModel> GetById(int id)
    {
        var project = await _dbContext.Projects
            .Include(p=>p.Client)
            .Include(p=>p.Freelancer)
            .SingleOrDefaultAsync(p => p.Id == id);
        if (project == null) return null;

        return new ProjectDetailsViewModel(
            project.Id, 
            project.Title, 
            project.Description, 
            project.TotalCost, 
            project.StartedAt, 
            project.FinishedAt,
            project.Client.FisrtName,
            project.Client.LastName,
            project.Freelancer.FisrtName,
            project.Freelancer.LastName
            );
    }

    public async void Start(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        project?.Start();
        await _dbContext.SaveChangesAsync();
    }

    public async void Update(UpdateProjectInputModel inputModel)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == inputModel.Id);
        project?.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        await _dbContext.SaveChangesAsync();
    }
}
