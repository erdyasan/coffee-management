namespace EY.CoffeeManagement.App.Application.Dtos.BaseDtos;

public record PaginateRequest(int Page, int Size)
{
    public int Skip() => (Page - 1) * Size;
    public int Take() => Size;

    public static PaginateRequest FromSkip(int? skip, int? size)
    {
        skip ??= 0;
        size ??= 25;
        if (skip == 0)
        {
            return new PaginateRequest(1, size.Value);
        }

        return new PaginateRequest((skip.Value / size.Value) + 1, size.Value);
    }
};

public record PaginateResponse<T>(IEnumerable<T> list, int page, int size, int totalCount)
{
    public int TotalPage => totalCount != 0 && size != 0 ? totalCount / size : 1;
};

public static class PR
{
    public static PaginateResponse<T> ToResponse<T>(this PaginateRequest request, IEnumerable<T> list, int totalCount)
    {
        return new PaginateResponse<T>(list, request.Page, request.Size, totalCount);
    }
}