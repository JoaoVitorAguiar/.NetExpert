using DevFreela.Infrastructure.Persistense;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Project.CreateProject;

// Informações para cadastrar o projeto
public class CreateProjectCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ClientId { get; set; }
    public int FreelancerId { get; set; }
    public decimal TotalCost { get; set; }
}
