using FluentValidation;
using ZooShop.Dtos.CreateDtos;

namespace ZooShop.Validators;

public class UploadProductImageValidator : AbstractValidator<UploadProductImageDto>
{
    private readonly string[] _validExtensions = [".jpg", ".png"];

    public UploadProductImageValidator()
    {
        RuleFor(c => c.Image)
            .NotEmpty()
            .WithMessage("Картинка не должна быть пустой")
            .Must(c =>
            {
                var extension = Path.GetExtension(c.FileName);
                return _validExtensions.Contains(extension);
            })
            .WithMessage($"Картинка должна быть с форматом: {string.Join(',', _validExtensions)}");
    }
}