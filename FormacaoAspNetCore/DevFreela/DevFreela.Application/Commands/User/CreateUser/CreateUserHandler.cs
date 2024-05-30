using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.User.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly IAuthService _authService;

    public CreateUserHandler(DevFreelaDbContext dbContext, IAuthService authService)
    {
        _dbContext = dbContext;
        _authService = authService;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);
            await _dbContext.Users.AddAsync(new Core.Entities.Users.User(
                request.FisrtName,
                request.LastName,
                request.Email,
                passwordHash,
                request.Role,
                request.BirthDate));
            await _dbContext.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
