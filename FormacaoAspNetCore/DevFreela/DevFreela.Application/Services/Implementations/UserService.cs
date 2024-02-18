using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities.Users;
using DevFreela.Infrastructure.Persistense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations;

public class UserService : IUserServices
{
    private readonly DevFreelaDbContext _dbContext;
    public UserService(DevFreelaDbContext devFreelaDbContext) 
    { 
        _dbContext = devFreelaDbContext;
    }
    public UserViewModel GetById(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        var userViewModel = new UserViewModel(
            user.Id, 
            user.FisrtName, 
            user.LastName, 
            user.Email);
        return userViewModel;
    }

    public bool Login(UserLoginInputModel inputModel)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == inputModel.Email);
        return user.PasswordHash == inputModel.PasswordHash ? false : true;
    }

    public int Register(UserRegisterInputModel inputModel)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == inputModel.Email);
        if (user != null) {
            return 0;
        }

        _dbContext.Users.Add(new User(
            inputModel.FisrtName,
            inputModel.LastName,
            inputModel.Email,
            inputModel.BirthDate
            ));
        return 1;

    }
}
