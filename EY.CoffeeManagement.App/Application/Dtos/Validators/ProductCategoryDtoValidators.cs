using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos.Validators;

public sealed class CreateProductCategoryDtoValidator : AbstractValidator<CreateProductCategoryDto>
{
    public CreateProductCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}

public sealed class UpdateProductCategoryDtoValidator : AbstractValidator<UpdateProductCategoryDto>
{
    public UpdateProductCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}