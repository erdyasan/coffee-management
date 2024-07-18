using EY.CoffeeManagement.App.Application.Services.Base;
using EY.CoffeeManagement.App.Application.Services.DomainServices.Contracts;
using EY.CoffeeManagement.App.Domain.DeskEntities;
using EY.CoffeeManagement.App.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace EY.CoffeeManagement.App.Application.Services.DomainServices.Concretes;

internal class DeskService : BaseService<Desk>, IDeskService
{
    public DeskService(IServiceScopeFactory serviceScopeFactory, CoffeeManagementContext context) : base(serviceScopeFactory, context)
    {
    }
}