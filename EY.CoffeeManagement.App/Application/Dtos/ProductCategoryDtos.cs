using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos;

public sealed record ListProductCategoryDto(Guid id, string Name);

public sealed record DetailProductCategoryDto(Guid id, string Name);

public sealed record CreateProductCategoryDto(string Name);

public sealed record UpdateProductCategoryDto(string Name);

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