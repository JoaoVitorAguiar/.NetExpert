using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject;

// Trata as informações e realiza efetivamente a persistência dos dados
public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, int>
{
    public Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
