using Tahseen.Service.DTOs.Feedbacks.Feedback;
using Tahseen.Service.DTOs.Feedbacks.SurveyResponses;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface ISurveyResponseService
{
    Task<SurveyResponseForResultDto> AddAsync(SurveyResponseForCreationDto dto);
    Task<SurveyResponseForResultDto> ModifyAsync(long id, SurveyResponseForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<SurveyResponseForResultDto?> RetrieveByIdAsync(long id);
    IQueryable<SurveyResponseForResultDto> RetrieveAll();
}