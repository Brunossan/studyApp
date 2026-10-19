using ArtificialTeacherApi.DTOs.Requests;
using ArtificialTeacherApi.DTOs.Responses;

namespace ArtificialTeacherApi.Services;

public interface ITechniqueService
{
    Task<TechniqueResponse> CreateAsync(Guid contentId, CreateTechniqueRequest request);
    Task<TechniqueResponse> UpdateAsync(Guid id, UpdateTechniqueRequest request);
    Task<IEnumerable<TechniqueResponse>> GetByContentAsync(Guid contentId);
    Task DeleteAsync(Guid id);
}
