using DevFreela.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    Task SaveChangesAsync(Project project);
    Task<List<Project>> GetAllAsync(); 
    Task<Project> GetByIdAsync(int id);

    Task<ProjectComment> CreateCommentAsync(ProjectComment comment);
    Task<Project> CreateProjectAsync(Project project); 

    Task DeleteProject(int id);

    Task FinishProject(int id);

    Task StartProject(int id);
}
