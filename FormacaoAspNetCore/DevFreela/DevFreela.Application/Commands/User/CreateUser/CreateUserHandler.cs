using DevFreela.Infrastructure.Persistense;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DevFreela.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.User.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Unit>
{
    private readonly DevFreelaDbContext _dbContext;

    public CreateUserHandler(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
      
        if (user == null) 
        {
            await _dbContext.Users.AddAsync(new Core.Entities.Users.User(
                request.FisrtName,
                request.LastName,
                request.Email,
                request.PasswordHash,
                request.Role,
                request.BirthDate));
            await _dbContext.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
