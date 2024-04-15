using DevFreela.Core.Entities.Users;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistense.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _dbContext;

    public UserRepository(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
    {

        return await _dbContext
            .Users
            .FirstOrDefaultAsync(
                u => u.Email == email && u.PasswordHash == passwordHash);
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }
}
