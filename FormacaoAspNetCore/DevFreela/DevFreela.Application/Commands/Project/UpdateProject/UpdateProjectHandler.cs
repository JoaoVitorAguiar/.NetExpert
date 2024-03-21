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
    private readonly DevFreelaDbContext _dbContext;

    public UpdateProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);
        project?.Update(request.Title, request.Description, request.TotalCost);
        await _dbContext.SaveChangesAsync();
        return Unit.Value;
    }
}
