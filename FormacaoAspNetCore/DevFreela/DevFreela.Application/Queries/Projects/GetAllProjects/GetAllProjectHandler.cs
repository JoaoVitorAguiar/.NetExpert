using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetAllProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = _dbContext.Projects;
        var projectsViewModel = await projects
            .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
            .ToListAsync();

        return projectsViewModel;
    }
}
