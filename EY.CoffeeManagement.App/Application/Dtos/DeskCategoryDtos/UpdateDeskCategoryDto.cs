﻿namespace EY.CoffeeManagement.App.Application.Dtos.DeskCategoryDtos;

public sealed class UpdateDeskCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
}