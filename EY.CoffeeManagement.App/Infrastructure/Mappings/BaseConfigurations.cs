using EY.CoffeeManagement.App.Domain.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EY.CoffeeManagement.App.Infrastructure.Mappings;

public static class BaseConfigurations
{
    public static void AddBase<T>(this EntityTypeBuilder<T> builder, string schema, string tableName = "") where T : BaseEntity
    {
        builder.ToTable($"{GetTableName<T>(tableName)}", schema);
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasDefaultValueSql("uuid_generate_v4()");

        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("NOW()");

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasIndex(x => x.CreatedAt)
            .IsUnique(false)
            .IsDescending(true);

        builder.HasIndex(x => x.IsDeleted)
            .IsUnique(false)
            .IsDescending(false);
    }

    private static string GetTableName<T>(string tableName)
    {
        if (string.IsNullOrWhiteSpace(tableName))
        {
            return $"{typeof(T).Name}s";
        }

        return tableName;
    }
}