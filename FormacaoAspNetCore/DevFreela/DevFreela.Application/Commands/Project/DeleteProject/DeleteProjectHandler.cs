using DevFreela.Core.Repositories;
using MediatR;


namespace DevFreela.Application.Commands.Project.DeleteProject;

public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await _projectRepository.DeleteProject(request.Id);

        return Unit.Value;
    }
}
