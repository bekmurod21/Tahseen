using Tahseen.Service.DTOs.Feedbacks.Feedback;
using Tahseen.Service.DTOs.Feedbacks.News;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface INewsService
{
    Task<NewsForResultDto> AddAsync(NewsForCreationDto dto);
    Task<NewsForResultDto> ModifyAsync(long id, NewsForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<NewsForResultDto?> RetrieveByIdAsync(long id);
    IQueryable<NewsForResultDto> RetrieveAll();
}