using Tahseen.Service.DTOs.Books.Publishers;
using Tahseen.Service.DTOs.Feedbacks.Feedback;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface IFeedbackService
{
    Task<FeedbackForResultDto> AddAsync(FeedbackForCreationDto dto);
    Task<FeedbackForResultDto> ModifyAsync(long id, FeedbackForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<FeedbackForResultDto?> RetrieveByIdAsync(long id);
    IQueryable<FeedbackForResultDto> RetrieveAll();
}