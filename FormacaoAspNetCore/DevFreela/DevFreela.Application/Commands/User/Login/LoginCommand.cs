using DevFreela.Application.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.User.Login;

public class LoginCommand: IRequest<LoginUserViewModel>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
