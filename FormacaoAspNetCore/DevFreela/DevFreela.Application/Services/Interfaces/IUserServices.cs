using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserServices
{
    Task<UserViewModel> GetById(int id);
    Task<int> Register(UserRegisterInputModel inputModel);
    Task<bool> Login(UserLoginInputModel inputModel);
}
