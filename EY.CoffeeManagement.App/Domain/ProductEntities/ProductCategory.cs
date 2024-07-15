using EY.CoffeeManagement.App.Domain.BaseEntities;

namespace EY.CoffeeManagement.App.Domain.ProductEntities;

public sealed class ProductCategory : BaseEntity
{
    public required string Name { get; set; }

    #region Navigations

    public ICollection<Product>? Products { get; set; }

    #endregion
}