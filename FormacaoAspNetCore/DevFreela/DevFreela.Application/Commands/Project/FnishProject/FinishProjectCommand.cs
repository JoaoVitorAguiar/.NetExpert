using MediatR;

namespace DevFreela.Application.Commands.Project.FnishProject;

public class FinishProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string CreditCardNumber { get; set; }
    public string Cvv { get; set; }
    public DateTime ExpiresAt { get; set; }
    public string FullName { get; set; }
}
