using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetByIdProjects;

public class GetByIdProjectHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel>
{
    private readonly DevFreelaDbContext _dbContext;

    public GetByIdProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects
    .Include(p => p.Client)
    .Include(p => p.Freelancer)
    .SingleOrDefaultAsync(p => p.Id == request.Id);
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
}
