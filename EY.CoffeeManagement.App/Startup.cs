using System.Globalization;
using System.Reflection;
using EY.CoffeeManagement.App.Application.Services.DomainServices.Concretes;
using EY.CoffeeManagement.App.Application.Services.DomainServices.Contracts;
using EY.CoffeeManagement.App.Domain.DeskEntities;
using EY.CoffeeManagement.App.Infrastructure.Persistence;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EY.CoffeeManagement.App;

public static class Startup
{
    public static void AddCoffeeManagementApp(this IServiceCollection services, IConfiguration configuration)
    {
        Assembly currentAssembly = typeof(Startup).Assembly;

        // Change service lifetime!
        services.AddDbContext<CoffeeManagementContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Postgre")), ServiceLifetime.Transient);


        #region Services

        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IDeskCategoryService, DeskCategoryService>();
        services.AddScoped<IDeskService, DeskService>();

        #endregion

        #region FluentValidation

        services.AddValidatorsFromAssembly(currentAssembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-tr");

        #endregion

        #region Mapster

        TypeAdapterConfig.GlobalSettings.Scan(currentAssembly);

        #endregion
    }
}