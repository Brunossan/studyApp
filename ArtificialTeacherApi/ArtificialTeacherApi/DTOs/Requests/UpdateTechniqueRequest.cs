using System.ComponentModel.DataAnnotations;

namespace ArtificialTeacherApi.DTOs.Requests;

public class UpdateTechniqueRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required(ErrorMessage = "GeneratedContent is required.")]
    public string GeneratedContent { get; set; } = string.Empty;

    public bool IsFavorite { get; set; }
}
