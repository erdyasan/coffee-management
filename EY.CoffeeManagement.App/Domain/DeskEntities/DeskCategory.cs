using EY.CoffeeManagement.App.Domain.BaseEntities;

namespace EY.CoffeeManagement.App.Domain.DeskEntities;

public sealed class DeskCategory : BaseEntity
{
    public required string Name { get; set; }
    public int SortOrder { get; set; }

    #region Navigations

    public ICollection<Desk>? Desks { get; set; }

    #endregion
}