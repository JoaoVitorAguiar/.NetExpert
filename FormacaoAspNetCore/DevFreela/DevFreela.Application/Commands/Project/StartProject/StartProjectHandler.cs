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
    public StartProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
        
    private readonly DevFreelaDbContext _dbContext;

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);
        project?.Start();
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}

