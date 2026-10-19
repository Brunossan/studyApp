using ArtificialTeacherApi.DTOs.Requests;
using ArtificialTeacherApi.DTOs.Responses;

namespace ArtificialTeacherApi.Services;

public interface IContentService
{
    Task<ContentResponse> CreateAsync(CreateContentRequest request);
    Task<PagedResponse<ContentListItemResponse>> GetPagedAsync(int page, int pageSize);
}
