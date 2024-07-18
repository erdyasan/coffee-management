using EY.CoffeeManagement.App.Application.Dtos.DeskCategoryDtos;
using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos.Validators.DeskCategoryValidators;

public sealed class CreateDeskCategoryValidator : AbstractValidator<CreateDeskCategoryDto>
{
    public CreateDeskCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}