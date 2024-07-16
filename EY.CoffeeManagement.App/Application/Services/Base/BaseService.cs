using EY.CoffeeManagement.App.Application.Dtos.BaseDtos;
using EY.CoffeeManagement.App.Domain.BaseEntities;
using EY.CoffeeManagement.App.Infrastructure.Persistence;
using EY.CustomResult;
using EY.CustomResult.Extensions;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EY.CoffeeManagement.App.Application.Services.Base;

public abstract class BaseService<T> : IBaseService where T : BaseEntity
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly CoffeeManagementContext _context;

    protected BaseService(IServiceScopeFactory serviceScopeFactory, CoffeeManagementContext context)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _context = context;
    }

    public virtual async Task<Result<Guid>> CreateAsync<TCreateRequest>(TCreateRequest request, CancellationToken cancellationToken = default)
    {
        var validationResult = await Validate<TCreateRequest>(request);
        if (validationResult.IsFail)
        {
            return Result.Fail<Guid>(validationResult.Error);
        }

        var entry = request.Adapt<T>();

        await _context.Set<T>().AddAsync(entry, cancellationToken);
        try
        {
            var savingResult = await _context.SaveChangesAsync(cancellationToken: cancellationToken);

            return Result.FromPredicate(() => savingResult > 0)
                .Map(() => entry.Id, new Error("500", "Entry couldnt saved"));
        }
        catch (Exception e)
        {
            return Result.Fail<Guid>(new Error("500", "An Error occurred while saving changes", new List<Error>
            {
                new Error(e.Source ?? string.Empty, e.Message)
            }));
        }
    }

    public virtual async Task<Result<Guid>> UpdateAsync<TUpdateRequest>(Guid id, TUpdateRequest request, CancellationToken cancellationToken = default)
    {
        var validationResult = await Validate(request);

        if (validationResult.IsFail)
        {
            return validationResult.Map(() => Guid.Empty, validationResult.Error);
        }

        var entry = await _context.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (entry == null)
        {
            return Result.Fail<Guid>(new Error("404", "Not Found"));
        }

        _context.Set<T>()
            .Entry(entry)
            .CurrentValues
            .SetValues(request!);

        var savingResult = await _context.SaveChangesAsync(cancellationToken: cancellationToken);
        return Result.FromPredicate(() => savingResult > 0)
            .Map(() => entry.Id, new Error("400", "Nothing changed"));
    }

    public virtual async Task<Result<TDetailDto>> DetailAsync<TDetailDto>(Guid id, CancellationToken cancellationToken = default)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return await _context
            .Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ProjectToType<TDetailDto>()
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
#pragma warning restore CS8604 // Possible null reference argument.
    }

    public virtual async Task<Result<PaginateResponse<TListDto>>> PaginateAsync<TListDto>(PaginateRequest request, CancellationToken cancellationToken = default)
    {
        var queryable = _context.Set<T>().AsNoTracking();

        var totalCount = await queryable.CountAsync(cancellationToken: cancellationToken);
        var results = await queryable
            .OrderByDescending(x => x.CreatedAt)
            .ProjectToType<TListDto>()
            .Skip(request.Skip())
            .Take(request.Take())
            .ToListAsync(cancellationToken: cancellationToken);

        return request.ToResponse(results, totalCount);
    }

    public virtual async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entry = await _context.Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);

        if (entry == null)
        {
            return Result.Fail(new Error("404", "Couldnt found"));
        }

        _context.Remove(entry);

        var savingResult = await _context.SaveChangesAsync(cancellationToken: cancellationToken);

        return Result.FromPredicate(() => savingResult > 0);
    }

    private async Task<Result> Validate<TRequest>(TRequest request)
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var validator = scope.ServiceProvider.GetRequiredService<IValidator<TRequest>>();

        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.IsValid)
        {
            return Result.Success();
        }

        return Result.Fail(new Error("400", "Request Is Not Valid", validationResult.Errors.Select(x => new Error(x.ErrorCode, x.ErrorMessage)).ToList()));
    }
}