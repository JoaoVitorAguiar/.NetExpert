namespace DevFreela.Application.InputModel;

public class UserLoginInputModel
{
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
}