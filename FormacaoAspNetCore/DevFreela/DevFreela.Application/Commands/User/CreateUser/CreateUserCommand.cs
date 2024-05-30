using MediatR;

namespace DevFreela.Application.Commands.User.CreateUser;

public class CreateUserCommand : IRequest<Unit>
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public DateTime BirthDate { get; set; }
}
