using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Service.Exceptions;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Feedbacks.UserRatings;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Service.Services.FeedbackService;

public class UserRatingService : IUserRatingService
{
    private readonly IMapper mapper;

    private readonly IRepository<UserRatings> repository;
    public UserRatingService(IMapper mapper, IRepository<UserRatings> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<UserRatingForResultDto> AddAsync(UserRatingForCreationDto dto)
    {
        var mappedUserRating = this.mapper.Map<UserRatings>(dto);
        var userRating = await this.repository.CreateAsync(mappedUserRating);
        return this.mapper.Map<UserRatingForResultDto>(userRating);
    }
    // o'zgartiriladi
    public async Task<UserRatingForResultDto> ModifyAsync(UserRatingForUpdateDto dto)
    {
        var userRating = await this.repository.SelectByIdAsync(dto.Id);
        if (userRating == null && userRating.IsDeleted)
            throw new TahseenException(404, "UserRating not found");

        var mappedUserRating = this.mapper.Map(dto,userRating);
        var result = await this.repository.UpdateAsync(mappedUserRating);

        return this.mapper.Map<UserRatingForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long Id)=>await this.repository.DeleteAsync(Id);
 

    public IQueryable<UserRatingForResultDto> RetrieveAllAsync()
    {
        var results = this.repository.SelectAll().Where(t => !t.IsDeleted);
        return mapper.Map<IQueryable<UserRatingForResultDto>>(results);
    }

    public async ValueTask<UserRatingForResultDto> RetrieveByIdAsync(long id)
    {
        var result = await this.repository.SelectByIdAsync(id);
        if (result == null && result.IsDeleted)
            throw new TahseenException(404, "UserRating not found");

        return mapper.Map<UserRatingForResultDto>(result);
    }

    public async ValueTask<UserRatingForResultDto> RetrieveByUserId(long userId)
    {
        var result = this.repository.SelectAll().Where(t=>t.UserId == userId && !t.IsDeleted);
        if (result == null)
            throw new TahseenException(404, "UserRating not found");
        return mapper.Map<UserRatingForResultDto>(result);
    }
}
