using EY.CoffeeManagement.App.Application.Dtos.BaseDtos;
using EY.CustomResult;

namespace EY.CoffeeManagement.App.Application.Services.Base;

public interface IBaseService
{
    Task<Result<Guid>> CreateAsync<TCreateRequest>(TCreateRequest request, CancellationToken cancellationToken = default);
    Task<Result<Guid>> UpdateAsync<TUpdateRequest>(Guid id, TUpdateRequest request, CancellationToken cancellationToken = default);
    Task<Result<TDetailDto>> DetailAsync<TDetailDto>(Guid id, CancellationToken cancellationToken = default);
    Task<Result<PaginateResponse<TListDto>>> PaginateAsync<TListDto>(PaginateRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}