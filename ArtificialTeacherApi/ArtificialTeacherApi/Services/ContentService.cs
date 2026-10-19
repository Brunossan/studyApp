using ArtificialTeacherApi.Data;
using ArtificialTeacherApi.DTOs.Requests;
using ArtificialTeacherApi.DTOs.Responses;
using ArtificialTeacherApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtificialTeacherApi.Services;

public class ContentService(AppDbContext db) : IContentService
{
    public async Task<ContentResponse> CreateAsync(CreateContentRequest request)
    {
        var content = new Content
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Category = request.Category,
            OriginalText = request.OriginalText,
            Notes = request.Notes,
            CreatedAt = DateTime.UtcNow
        };

        db.Contents.Add(content);
        await db.SaveChangesAsync();

        return MapToResponse(content);
    }

    public async Task<PagedResponse<ContentListItemResponse>> GetPagedAsync(int page, int pageSize)
    {
        var query = db.Contents.AsNoTracking();

        var totalRecords = await query.CountAsync();

        var items = await query
            .OrderByDescending(c => c.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => new ContentListItemResponse
            {
                Id = c.Id,
                Title = c.Title,
                Category = c.Category,
                TotalTechniques = c.Techniques.Count,
                CreatedAt = c.CreatedAt
            })
            .ToListAsync();

        return new PagedResponse<ContentListItemResponse>
        {
            Items = items,
            Page = page,
            PageSize = pageSize,
            TotalRecords = totalRecords
        };
    }

    private static ContentResponse MapToResponse(Content content) => new()
    {
        Id = content.Id,
        Title = content.Title,
        Category = content.Category,
        OriginalText = content.OriginalText,
        Notes = content.Notes,
        CreatedAt = content.CreatedAt
    };
}
