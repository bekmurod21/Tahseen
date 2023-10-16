using Tahseen.Service.DTOs.Feedbacks.UserMessages;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface IUserMessageService
{
    Task<UserMessageForResultDto> AddAsync(UserMessageForCreationDto dto);
    Task<UserMessageForResultDto> ModifyAsync(long id,UserMessageForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<UserMessageForResultDto> RetrieveByIdAsync(long id);
    IQueryable<UserMessageForResultDto> RetrieveAll();
}
