using ArtificialTeacherApi.Enums;

namespace ArtificialTeacherApi.Models;

public class MemorizationTechnique
{
    public Guid Id { get; set; }
    public Guid ContentId { get; set; }
    public TechniqueType TechniqueType { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string GeneratedContent { get; set; } = string.Empty;
    public GenerationOrigin GenerationOrigin { get; set; }
    public bool IsFavorite { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Content Content { get; set; } = null!;
}
