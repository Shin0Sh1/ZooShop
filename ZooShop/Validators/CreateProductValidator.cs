using FluentValidation;
using ZooShop.Application.Dtos.CreateDtos;

namespace ZooShop.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Название обязательно")
            .MaximumLength(250)
            .WithMessage("Название не может быть длиннее 250 символов");

        RuleFor(p => p.Price)
            .NotEmpty()
            .WithMessage("Цена обязательна")
            .GreaterThan(0)
            .WithMessage("Цена должна быть больше нуля");

        RuleFor(p => p.Quantity)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Количество должно быть больше нуля");
    }
}