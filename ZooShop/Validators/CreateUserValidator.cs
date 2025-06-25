using FluentValidation;
using ZooShop.Application.Dtos.CreateDtos;

namespace ZooShop.Validators;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    private const string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

    public CreateUserValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Почта обязательна")
            .EmailAddress()
            .WithMessage("Некорректная почта");

        RuleFor(u => u.Password)
            .Matches(PasswordRegex)
            .WithMessage("Пароль некорректный");
    }
}