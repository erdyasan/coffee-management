using EY.CoffeeManagement.App.Domain.DeskEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EY.CoffeeManagement.App.Infrastructure.Mappings;

internal sealed class DeskConfiguration : IEntityTypeConfiguration<Desk>
{
    public void Configure(EntityTypeBuilder<Desk> builder)
    {
        builder.AddBase("Desk", "Desks");
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder.Property(x => x.SortOrder)
            .HasDefaultValue(0);

        builder.HasIndex(x => x.Name, "IX_Desk_Name")
            .IsUnique(true)
            .IsDescending(true);
        builder.HasIndex(x => x.SortOrder, "IX_Desk_SortOrder")
            .IsUnique(false)
            .IsDescending(true);

        #region Navigations

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Desks)
            .HasForeignKey(x => x.DeskCategoryId);

        #endregion
    }
}