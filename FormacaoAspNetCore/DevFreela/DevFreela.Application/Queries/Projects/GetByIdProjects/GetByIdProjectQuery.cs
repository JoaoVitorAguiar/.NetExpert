using DevFreela.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetByIdProjects;

public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel>
{
    public GetByIdProjectQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
