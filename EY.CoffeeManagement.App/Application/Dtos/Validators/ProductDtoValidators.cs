using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos.Validators;

public sealed class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.Price)
            .GreaterThan(x => 0);
        RuleFor(x => x.ProductCategoryId)
            .NotEmpty()
            .Must(x => x != Guid.Empty)
            .WithMessage("Geçerli bir kategori seçiniz.");
    }
}