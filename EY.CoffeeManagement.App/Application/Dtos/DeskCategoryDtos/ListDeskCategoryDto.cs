namespace EY.CoffeeManagement.App.Application.Dtos.DeskCategoryDtos;

public record ListDeskCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
};