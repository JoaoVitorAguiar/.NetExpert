namespace DevFreela.Application.ViewModel;

public class LoginUserViewModel
{
    public string Email { get; private set; }
    public string Token { get; private set; }

    public LoginUserViewModel( string email, string token)
    {
        Token = token;
        Email = email;
    }
}