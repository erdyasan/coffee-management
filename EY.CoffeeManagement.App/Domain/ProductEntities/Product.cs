using EY.CoffeeManagement.App.Domain.BaseEntities;

namespace EY.CoffeeManagement.App.Domain.ProductEntities;

public sealed class Product : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }

    public Guid ProductCategoryId { get; set; }

    #region Navigations

    public ProductCategory? Category { get; set; }

    #endregion
}