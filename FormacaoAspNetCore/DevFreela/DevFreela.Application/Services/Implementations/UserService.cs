using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities.Users;
using DevFreela.Infrastructure.Persistense;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserServices
{
    private readonly DevFreelaDbContext _dbContext;
    public UserService(DevFreelaDbContext devFreelaDbContext)
    {
        _dbContext = devFreelaDbContext;
    }
    public async Task<UserViewModel> GetById(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) return null;

        var userViewModel = new UserViewModel(
            user.Id,
            user.FisrtName,
            user.LastName,
            user.Email);

        return userViewModel;
    }

    public async Task<bool> Login(UserLoginInputModel inputModel)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == inputModel.Email);
        if (user == null) return false;

        return user.PasswordHash != inputModel.PasswordHash;
    }

    public async Task<int> Register(UserRegisterInputModel inputModel)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == inputModel.Email);
        if (user != null)
        {
            return 0;
        }

        await _dbContext.Users.AddAsync(new User(
            inputModel.FisrtName,
            inputModel.LastName,
            inputModel.Email,
            inputModel.PasswordHash,
            inputModel.Role,
            inputModel.BirthDate));
        return await _dbContext.SaveChangesAsync();
    }
}
