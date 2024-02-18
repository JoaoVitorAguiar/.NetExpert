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
    UserViewModel GetById(int id);
    int Register(UserRegisterInputModel inputModel);
    bool Login(UserLoginInputModel inputModel);
}
