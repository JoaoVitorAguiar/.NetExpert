using DevFreela.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetAllProjects;

public class GetAllProjectsQuery: IRequest<List<ProjectViewModel>>
{
    public string Query { get; private set; }

    public GetAllProjectsQuery(string query)
    {
        Query = query;
    }
}
