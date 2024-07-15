using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EY.CoffeeManagement.App.Infrastructure.Persistence;

public sealed class CoffeeManagementContextDesignTimeFactory : IDesignTimeDbContextFactory<CoffeeManagementContext>
{
    public CoffeeManagementContext CreateDbContext(string[] args)
    {
        var conString = args.FirstOrDefault();
        ArgumentException.ThrowIfNullOrWhiteSpace(conString);

        var optionsBuilder = new DbContextOptionsBuilder<CoffeeManagementContext>();
        optionsBuilder.UseNpgsql(conString);

        return new CoffeeManagementContext(optionsBuilder.Options);
    }
}