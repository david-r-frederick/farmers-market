namespace Core.DataModel.Models;

public class PagedResult<T>(List<T> items, int pageNumber, int pageSize, int totalCount)
{
    public List<T> Items { get; set; } = items;

    public int PageNumber { get; set; } = pageNumber;

    public int PageSize { get; set; } = pageSize;

    public int TotalCount { get; set; } = totalCount;

    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}