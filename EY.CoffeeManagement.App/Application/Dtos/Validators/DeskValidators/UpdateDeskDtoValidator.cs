using EY.CoffeeManagement.App.Application.Dtos.DeskDtos;
using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos.Validators.DeskValidators;

public sealed class UpdateDeskDtoValidator : AbstractValidator<UpdateDeskDto>
{
    public UpdateDeskDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.DeskCategoryId)
            .NotEmpty()
            .Must(x => x != Guid.Empty);
    }
}