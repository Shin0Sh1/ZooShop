using FluentValidation;
using ZooShop.Dtos.CreateDtos;

namespace ZooShop.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.OrderItems)
            .NotEmpty()
            .WithMessage("В заказе должна быть хотя бы одна позиция");
    }
}