using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQuery : IRequest<List<ProjectViewModel>>
{
    public string Query { get; private set; }

    public GetAllProjectsQuery(string query)
    {
        Query = query;
    }
}
