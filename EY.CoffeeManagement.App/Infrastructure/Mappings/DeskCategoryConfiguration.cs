using EY.CoffeeManagement.App.Domain.DeskEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EY.CoffeeManagement.App.Infrastructure.Mappings;

internal sealed class DeskCategoryConfiguration : IEntityTypeConfiguration<DeskCategory>
{
    public void Configure(EntityTypeBuilder<DeskCategory> builder)
    {
        builder.AddBase("Desk", "DeskCategories");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(x => x.SortOrder)
            .IsRequired(true)
            .HasDefaultValue(0);

        #region Navigations

        builder.HasMany(x => x.Desks)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.DeskCategoryId);

        #endregion
    }
}