namespace ArtificialTeacherApi.DTOs.Responses;

public class ContentListItemResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Category { get; set; }
    public int TotalTechniques { get; set; }
    public DateTime CreatedAt { get; set; }
}
