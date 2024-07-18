namespace EY.CoffeeManagement.App.Application.Dtos.DeskDtos;

public sealed class UpdateDeskDto
{
    public string Name { get; set; } = string.Empty;
    public Guid DeskCategoryId { get; set; }
    public int SortOrder { get; set; }
}