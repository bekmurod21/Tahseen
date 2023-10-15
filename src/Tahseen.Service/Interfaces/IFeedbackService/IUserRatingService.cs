using Tahseen.Service.DTOs.Feedbacks.UserRatings;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface IUserRatingService
{
    Task<UserRatingForResultDto> AddAsync(UserRatingForCreationDto dto);
    Task<UserRatingForResultDto> ModifyAsync(UserRatingForUpdateDto dto);
    Task<bool> RemoveAsync(long Id);
    ValueTask<UserRatingForResultDto> RetrieveByIdAsync(long id);
    ValueTask<UserRatingForResultDto> RetrieveByUserId(long userId);
    IQueryable<UserRatingForResultDto> RetrieveAllAsync();
}
