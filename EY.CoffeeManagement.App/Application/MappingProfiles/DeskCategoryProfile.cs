using EY.CoffeeManagement.App.Application.Dtos.DeskCategoryDtos;
using EY.CoffeeManagement.App.Domain.DeskEntities;
using Mapster;

namespace EY.CoffeeManagement.App.Application.MappingProfiles;

public sealed class DeskCategoryProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<DeskCategory, ListDeskCategoryDto>()
            .Map(x => x.SortOrder, x => x.SortOrder)
            .Map(x => x.Id, x => x.Id)
            .Map(x => x.Name, x => x.Name);
        config.NewConfig<DeskCategory, UpdateDeskCategoryDto>()
            .Map(x => x.SortOrder, x => x.SortOrder)
            .Map(x => x.Name, x => x.Name);
    }
}