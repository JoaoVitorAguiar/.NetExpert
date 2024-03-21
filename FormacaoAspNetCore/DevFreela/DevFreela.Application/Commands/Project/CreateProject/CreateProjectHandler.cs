using DevFreela.Core.Entities.Projects;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.CreateProject;

// Trata as informações e realiza efetivamente a persistência dos dados
public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly DevFreelaDbContext _dbContext;
    public CreateProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new DevFreela.Core.Entities.Projects.Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
        return project.Id;
    }
}
