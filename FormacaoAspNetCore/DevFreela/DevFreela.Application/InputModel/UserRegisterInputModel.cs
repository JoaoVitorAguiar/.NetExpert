﻿namespace DevFreela.Application.InputModel;
public class UserRegisterInputModel
{
    public string FisrtName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public DateTime BirthDate { get; set; }
}
