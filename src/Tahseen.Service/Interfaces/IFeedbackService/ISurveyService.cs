using Tahseen.Service.DTOs.Feedbacks.Surveys;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface ISurveyService
{
    Task<SurveyForResultDto> AddAsync(SurveyForCreationDto dto);
    Task<SurveyForResultDto> ModifyAsync(long id, SurveyForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<SurveyForResultDto?> RetrieveByIdAsync(long id);
    IQueryable<SurveyForResultDto> RetrieveAll();
}