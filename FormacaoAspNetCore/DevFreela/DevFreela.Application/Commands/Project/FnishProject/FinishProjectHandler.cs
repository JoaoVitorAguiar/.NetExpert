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
    private readonly DevFreelaDbContext _dbContext;

    public FinishProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);
        project?.Finish();
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }

}

