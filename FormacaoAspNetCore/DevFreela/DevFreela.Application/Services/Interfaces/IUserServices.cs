using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;

namespace DevFreela.Application.Services.Interfaces;

public interface IUserServices
{
    Task<UserViewModel> GetById(int id);
    Task<int> Register(UserRegisterInputModel inputModel);
    Task<bool> Login(UserLoginInputModel inputModel);
}
