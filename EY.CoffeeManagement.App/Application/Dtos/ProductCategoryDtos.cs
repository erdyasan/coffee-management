using FluentValidation;

namespace EY.CoffeeManagement.App.Application.Dtos;

public sealed record ListProductCategoryDto(Guid id, string Name);

public sealed record DetailProductCategoryDto(Guid id, string Name);

public sealed class CreateProductCategoryDto
{
    public string Name { get; set; } = string.Empty;

    public CreateProductCategoryDto()
    {
    }

    public CreateProductCategoryDto(string name)
    {
        Name = name;
    }
};

public sealed record UpdateProductCategoryDto
{
    public string Name { get; set; }

    public UpdateProductCategoryDto()
    {
    }

    public UpdateProductCategoryDto(string name)
    {
        Name = name;
    }
};
