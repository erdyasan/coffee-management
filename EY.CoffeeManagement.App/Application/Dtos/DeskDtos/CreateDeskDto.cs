namespace EY.CoffeeManagement.App.Application.Dtos.DeskDtos;

public class CreateDeskDto
{
    public Guid DeskCategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
}