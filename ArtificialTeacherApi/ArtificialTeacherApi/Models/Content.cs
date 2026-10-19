using ArtificialTeacherApi.Enums;

namespace ArtificialTeacherApi.Models;

public class Content
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Category { get; set; }
    public string OriginalText { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<MemorizationTechnique> Techniques { get; set; } = [];
}
