using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Commands.User.Login;

public class LoginCommand : IRequest<LoginUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
