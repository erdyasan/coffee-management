using EY.CoffeeManagement.App.Domain.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EY.CoffeeManagement.App.Infrastructure.Mappings;

internal sealed class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.AddBase("Product", "ProductCategories");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(100)");

        #region Navigations

        builder.HasMany(x => x.Products)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.ProductCategoryId);

        #endregion
    }
}