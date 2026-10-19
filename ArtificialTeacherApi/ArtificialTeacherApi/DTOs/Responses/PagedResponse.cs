namespace ArtificialTeacherApi.DTOs.Responses;

public class PagedResponse<T>
{
    public IEnumerable<T> Items { get; set; } = [];
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
}
