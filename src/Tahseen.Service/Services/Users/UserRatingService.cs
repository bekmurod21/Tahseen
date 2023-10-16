using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Service.Exceptions;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Feedbacks.UserRatings;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Service.Services.Users;

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
        var mappedUserRating = mapper.Map<UserRatings>(dto);
        var userRating = await repository.CreateAsync(mappedUserRating);
        return mapper.Map<UserRatingForResultDto>(userRating);
    }
    // o'zgartiriladi
    public async Task<UserRatingForResultDto> ModifyAsync(UserRatingForUpdateDto dto)
    {
        var userRating = await repository.SelectByIdAsync(dto.Id);
        if (userRating == null && userRating.IsDeleted)
            throw new TahseenException(404, "UserRating not found");

        var mappedUserRating = mapper.Map(dto, userRating);
        var result = await repository.UpdateAsync(mappedUserRating);

        return mapper.Map<UserRatingForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long Id) => await repository.DeleteAsync(Id);


    public IQueryable<UserRatingForResultDto> RetrieveAllAsync()
    {
        var results = repository.SelectAll().Where(t => !t.IsDeleted);
        return mapper.Map<IQueryable<UserRatingForResultDto>>(results);
    }

    public async ValueTask<UserRatingForResultDto> RetrieveByIdAsync(long id)
    {
        var result = await repository.SelectByIdAsync(id);
        if (result == null && result.IsDeleted)
            throw new TahseenException(404, "UserRating not found");

        return mapper.Map<UserRatingForResultDto>(result);
    }

    public async ValueTask<UserRatingForResultDto> RetrieveByUserId(long userId)
    {
        var result = repository.SelectAll().Where(t => t.UserId == userId && !t.IsDeleted);
        if (result == null)
            throw new TahseenException(404, "UserRating not found");
        return mapper.Map<UserRatingForResultDto>(result);
    }
}
