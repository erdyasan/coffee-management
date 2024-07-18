using EY.CoffeeManagement.App.Application.Dtos.DeskCategoryDtos;
using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos.Validators.DeskCategoryValidators;

public sealed class UpdateDeskCategoryValidator : AbstractValidator<UpdateDeskCategoryDto>
{
    public UpdateDeskCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}