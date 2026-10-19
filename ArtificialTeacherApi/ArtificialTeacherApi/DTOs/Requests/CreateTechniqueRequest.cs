using System.ComponentModel.DataAnnotations;
using ArtificialTeacherApi.Enums;

namespace ArtificialTeacherApi.DTOs.Requests;

public class CreateTechniqueRequest
{
    [Required(ErrorMessage = "TechniqueType is required and must be a valid enum value.")]
    public TechniqueType TechniqueType { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required(ErrorMessage = "GeneratedContent is required.")]
    public string GeneratedContent { get; set; } = string.Empty;

    [Required(ErrorMessage = "GenerationOrigin is required and must be a valid enum value.")]
    public GenerationOrigin GenerationOrigin { get; set; }

    public bool IsFavorite { get; set; } = false;
}
