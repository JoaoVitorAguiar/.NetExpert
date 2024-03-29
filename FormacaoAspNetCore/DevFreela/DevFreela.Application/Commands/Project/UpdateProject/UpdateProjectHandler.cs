using DevFreela.Core.Entities.Projects;
using DevFreela.Core.Exceptions;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.UpdateProject;

public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);
        if (project != null)
        {
            project.Update(request.Title, request.Description, request.TotalCost);
            await _projectRepository.SaveChangesAsync(project);

        }
        return Unit.Value;
    }
}
