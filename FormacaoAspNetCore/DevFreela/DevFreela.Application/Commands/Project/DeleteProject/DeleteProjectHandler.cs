using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace DevFreela.Application.Commands.Project.DeleteProject;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;
    public DeleteProjectHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (project != null) 
        {
            project.Cancel();
            await _dbContext.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
