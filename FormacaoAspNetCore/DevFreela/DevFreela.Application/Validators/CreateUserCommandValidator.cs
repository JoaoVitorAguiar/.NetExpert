using DevFreela.Application.Commands.User.CreateUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("E-mail não válido.");

        RuleFor(u => u.PasswordHash)
            .Must(ValidPassword)
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula e um caractere especial.");

        RuleFor(u => u.FisrtName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Primeiro nome obrigatório.");

        RuleFor(u => u.LastName)
           .NotEmpty()
           .NotNull()
           .WithMessage("Sobrenome obrigatório.");

    }

    private bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");
        return regex.IsMatch(password);
    }
}
