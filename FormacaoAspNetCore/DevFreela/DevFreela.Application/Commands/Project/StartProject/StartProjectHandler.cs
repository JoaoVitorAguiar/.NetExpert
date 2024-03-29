using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.StartProject;

public class StartProjectHandler : IRequestHandler<StartProjectCommand, Unit>
{ 
        
    private readonly IProjectRepository _projectRepository;

    public StartProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        await _projectRepository.StartProject(request.Id);
        return Unit.Value;
    }
}

