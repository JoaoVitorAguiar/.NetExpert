using DevFreela.Application.ViewModel;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.User.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginUserViewModel>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginHandler(IAuthService authService, IUserRepository userRepository)
    {
        _authService = authService;
        _userRepository = userRepository;
    }

    public async Task<LoginUserViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Gerar hash de senha
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

        if (user == null) return null;

        var token = _authService.GenerateJwtToken(user.Email, user.Role);

        return new LoginUserViewModel(user.Email, token);

    }
}
