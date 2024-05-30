using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetByIdProjects;

public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel>
{
    public GetByIdProjectQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
