using ArtificialTeacherApi.DTOs.Requests;
using ArtificialTeacherApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtificialTeacherApi.Controllers;

[ApiController]
[Route("api/v1/contents")]
public class ContentsController(IContentService contentService) : ControllerBase
{
    /// <summary>Creates a new content item to memorize.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateContentRequest request)
    {
        var response = await contentService.CreateAsync(request);
        return CreatedAtAction(nameof(GetPaged), new { }, response);
    }

    /// <summary>Returns a paginated list of content items.</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var response = await contentService.GetPagedAsync(page, pageSize);
        return Ok(response);
    }
}
