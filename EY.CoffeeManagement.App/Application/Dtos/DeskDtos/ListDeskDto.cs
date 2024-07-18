namespace EY.CoffeeManagement.App.Application.Dtos.DeskDtos;

public class ListDeskDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int SortOrder { get; set; }
    public string CategoryName { get; set; }
}