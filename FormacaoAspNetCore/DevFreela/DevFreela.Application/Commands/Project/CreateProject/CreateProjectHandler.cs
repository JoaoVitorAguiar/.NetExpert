﻿using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.Project.CreateProject;

// Trata as informações e realiza efetivamente a persistência dos dados
public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new DevFreela.Core.Entities.Projects.Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);
        await _projectRepository.CreateProjectAsync(project);
        return project.Id;
    }
}
