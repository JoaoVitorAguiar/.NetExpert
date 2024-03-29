

using Azure.Core;
using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistense.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _dbContext;

    public ProjectRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Project>> GetAllAsync()
    {
        var projects = await _dbContext.Projects.ToListAsync();
        return projects;
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        var project = await _dbContext.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .SingleOrDefaultAsync(p => p.Id == id);

        return project;
    }

    public async Task<ProjectComment> CreateCommentAsync(ProjectComment comment)
    {
        if (comment == null) return null;
        await _dbContext.ProjectComment.AddAsync(comment);
        await _dbContext.SaveChangesAsync();
        return comment;
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        if (project == null) return null;
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
        return project;
    }

    public async Task DeleteProject(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        project?.Cancel();
        await _dbContext.SaveChangesAsync();
    }

    public async Task FinishProject(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        project?.Finish();
        await _dbContext.SaveChangesAsync();
    }

    public async Task StartProject(int id)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        project?.Start();
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync(Project project)
    {
        await _dbContext.SaveChangesAsync();
    }
}
