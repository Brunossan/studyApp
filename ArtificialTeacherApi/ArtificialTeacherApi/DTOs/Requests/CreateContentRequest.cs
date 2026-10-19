using System.ComponentModel.DataAnnotations;

namespace ArtificialTeacherApi.DTOs.Requests;

public class CreateContentRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Category { get; set; }

    [Required(ErrorMessage = "OriginalText is required.")]
    public string OriginalText { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Notes { get; set; }
}
