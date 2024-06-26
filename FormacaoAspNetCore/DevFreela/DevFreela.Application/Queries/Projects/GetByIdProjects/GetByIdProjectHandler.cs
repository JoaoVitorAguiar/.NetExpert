﻿using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetByIdProjects;

public class GetByIdProjectHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel>
{
    private readonly IProjectRepository _projectRepository;
    public GetByIdProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

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
