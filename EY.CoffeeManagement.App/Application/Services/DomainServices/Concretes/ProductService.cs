using EY.CoffeeManagement.App.Application.Services.Base;
using EY.CoffeeManagement.App.Application.Services.DomainServices.Contracts;
using EY.CoffeeManagement.App.Domain.ProductEntities;
using EY.CoffeeManagement.App.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace EY.CoffeeManagement.App.Application.Services.DomainServices.Concretes;

internal sealed class ProductService : BaseService<Product>, IProductService
{
    public ProductService(IServiceScopeFactory serviceScopeFactory, CoffeeManagementContext context) : base(serviceScopeFactory, context)
    {
    }
}