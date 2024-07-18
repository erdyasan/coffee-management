namespace EY.CoffeeManagement.App.Application.Dtos.DeskDtos;

public sealed class DetailDeskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int SortOrder { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;
}