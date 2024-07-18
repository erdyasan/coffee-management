using EY.CoffeeManagement.App.Application.Services.Base;
using EY.CoffeeManagement.App.Application.Services.DomainServices.Contracts;
using EY.CoffeeManagement.App.Domain.ProductEntities;
using EY.CoffeeManagement.App.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace EY.CoffeeManagement.App.Application.Services.DomainServices.Concretes;

internal class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
{
    public ProductCategoryService(IServiceScopeFactory serviceScopeFactory, CoffeeManagementContext context) : base(serviceScopeFactory, context)
    {
    }
}