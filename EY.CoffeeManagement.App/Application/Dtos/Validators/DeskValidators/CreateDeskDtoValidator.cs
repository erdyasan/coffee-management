using EY.CoffeeManagement.App.Application.Dtos.DeskDtos;
using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos.Validators.DeskValidators;

public sealed class CreateDeskDtoValidator : AbstractValidator<CreateDeskDto>
{
    public CreateDeskDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
        RuleFor(x => x.DeskCategoryId)
            .NotEmpty()
            .Must(x => x != Guid.Empty);
    }
}