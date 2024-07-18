using EY.CoffeeManagement.App.Application.Dtos;
using EY.CoffeeManagement.App.Domain.ProductEntities;
using Mapster;

namespace EY.CoffeeManagement.App.Application.MappingProfiles;

internal sealed class ProductAdapter : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<Product, DetailProductDto>()
            .Map(x => x.ProductCategoryId, x => x.ProductCategoryId)
            .Map(x => x.ProdutCategoryName, x => x.Category.Name);
    }
}