using ArtificialTeacherApi.DTOs.Requests;
using ArtificialTeacherApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtificialTeacherApi.Controllers;

[ApiController]
public class TechniquesController(ITechniqueService techniqueService) : ControllerBase
{
    /// <summary>Creates a new memorization technique associated with a content item.</summary>
    [HttpPost("api/v1/contents/{contentId:guid}/techniques")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(Guid contentId, [FromBody] CreateTechniqueRequest request)
    {
        var response = await techniqueService.CreateAsync(contentId, request);
        return CreatedAtAction(nameof(GetByContent), new { contentId }, response);
    }

    /// <summary>Updates an existing memorization technique.</summary>
    [HttpPut("api/v1/techniques/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTechniqueRequest request)
    {
        var response = await techniqueService.UpdateAsync(id, request);
        return Ok(response);
    }

    /// <summary>Returns all techniques for a specific content item.</summary>
    [HttpGet("api/v1/contents/{contentId:guid}/techniques")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByContent(Guid contentId)
    {
        var response = await techniqueService.GetByContentAsync(contentId);
        return Ok(response);
    }

    /// <summary>Deletes a specific memorization technique.</summary>
    [HttpDelete("api/v1/techniques/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await techniqueService.DeleteAsync(id);
        return NoContent();
    }
}
