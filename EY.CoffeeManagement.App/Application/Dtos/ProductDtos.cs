namespace EY.CoffeeManagement.App.Application.Dtos;

public sealed class CreateProductDto
{
    public Guid ProductCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

public sealed class UpdateProductDto
{
    public Guid ProductCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}

public sealed class ListProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public sealed class DetailProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid ProductCategoryId { get; set; }
    public string ProdutCategoryName { get; set; }
}