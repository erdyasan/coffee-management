using EY.CoffeeManagement.App.Domain.BaseEntities;

namespace EY.CoffeeManagement.App.Domain.DeskEntities;

public sealed class Desk : BaseEntity
{
    public Guid DeskCategoryId { get; set; }
    public required string Name { get; set; }
    public int SortOrder { get; set; }

    #region Navigations

    public DeskCategory? Category { get; set; }

    #endregion
}