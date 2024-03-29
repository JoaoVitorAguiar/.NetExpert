using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.FnishProject;

public class FinishProjectHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public FinishProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }


    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        await _projectRepository.FinishProject(request.Id);
        return Unit.Value;
    }

}

