using ArtificialTeacherApi.Data;
using ArtificialTeacherApi.DTOs.Requests;
using ArtificialTeacherApi.DTOs.Responses;
using ArtificialTeacherApi.Exceptions;
using ArtificialTeacherApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtificialTeacherApi.Services;

public class TechniqueService(AppDbContext db) : ITechniqueService
{
    public async Task<TechniqueResponse> CreateAsync(Guid contentId, CreateTechniqueRequest request)
    {
        var contentExists = await db.Contents.AnyAsync(c => c.Id == contentId);
        if (!contentExists)
            throw new NotFoundException($"The content with the specified ID was not found.");

        var technique = new MemorizationTechnique
        {
            Id = Guid.NewGuid(),
            ContentId = contentId,
            TechniqueType = request.TechniqueType,
            Title = request.Title,
            Description = request.Description,
            GeneratedContent = request.GeneratedContent,
            GenerationOrigin = request.GenerationOrigin,
            IsFavorite = request.IsFavorite,
            CreatedAt = DateTime.UtcNow
        };

        db.MemorizationTechniques.Add(technique);
        await db.SaveChangesAsync();

        return MapToResponse(technique);
    }

    public async Task<TechniqueResponse> UpdateAsync(Guid id, UpdateTechniqueRequest request)
    {
        var technique = await db.MemorizationTechniques.FindAsync(id)
            ?? throw new NotFoundException($"The technique with the specified ID was not found.");

        technique.Title = request.Title;
        technique.Description = request.Description;
        technique.GeneratedContent = request.GeneratedContent;
        technique.IsFavorite = request.IsFavorite;
        technique.UpdatedAt = DateTime.UtcNow;

        await db.SaveChangesAsync();

        return MapToResponse(technique);
    }

    public async Task<IEnumerable<TechniqueResponse>> GetByContentAsync(Guid contentId)
    {
        var contentExists = await db.Contents.AnyAsync(c => c.Id == contentId);
        if (!contentExists)
            throw new NotFoundException($"The content with the specified ID was not found.");

        return await db.MemorizationTechniques
            .AsNoTracking()
            .Where(t => t.ContentId == contentId)
            .OrderByDescending(t => t.CreatedAt)
            .Select(t => MapToResponse(t))
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var technique = await db.MemorizationTechniques.FindAsync(id)
            ?? throw new NotFoundException($"The technique with the specified ID was not found.");

        db.MemorizationTechniques.Remove(technique);
        await db.SaveChangesAsync();
    }

    private static TechniqueResponse MapToResponse(MemorizationTechnique t) => new()
    {
        Id = t.Id,
        ContentId = t.ContentId,
        TechniqueType = t.TechniqueType,
        Title = t.Title,
        Description = t.Description,
        GeneratedContent = t.GeneratedContent,
        GenerationOrigin = t.GenerationOrigin,
        IsFavorite = t.IsFavorite,
        CreatedAt = t.CreatedAt,
        UpdatedAt = t.UpdatedAt
    };
}
