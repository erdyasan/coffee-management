using EY.CoffeeManagement.App.Domain.AuthEntities;
using EY.CoffeeManagement.App.Domain.BaseEntities;
using EY.CoffeeManagement.App.Domain.DeskEntities;
using EY.CoffeeManagement.App.Domain.ProductEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EY.CoffeeManagement.App.Infrastructure.Persistence;

public sealed class CoffeeManagementContext : IdentityDbContext<CoffeManagementUser, CoffeManagementRole, Guid>
{
    public CoffeeManagementContext(DbContextOptions<CoffeeManagementContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

    public DbSet<Desk> Desks { get; set; } = null!;
    public DbSet<DeskCategory> DeskCategories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CoffeeManagementContext).Assembly);
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var baseEntries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in baseEntries)
        {
            var entryEntity = entry.Entity;
            switch (entry.State)
            {
                case EntityState.Added:
                    entryEntity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entryEntity.DeletedAt = DateTime.UtcNow;
                    entryEntity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                    break;
                case EntityState.Modified:
                    entryEntity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }


        return base.SaveChangesAsync(cancellationToken);
    }
}