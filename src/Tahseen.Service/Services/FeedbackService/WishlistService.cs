using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Feedback;
using Tahseen.Service.DTOs.Feedbacks.Wishlists;
using Tahseen.Service.Interfaces.IFeedbackService;

namespace Tahseen.Service.Services.FeedbackService;

public class WishlistService : IWishlistService
{
    private readonly IMapper mapper;
    private readonly IRepository<WishList> repository;

    public WishlistService(IMapper mapper, IRepository<WishList> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public Task<WishlistForResultDto> AddAsync(WishlistForCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<WishlistForResultDto> ModifyAsync(WishlistForUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(long Id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<WishlistForResultDto> RetrieveAll()
    {
        throw new NotImplementedException();
    }

    public ValueTask<WishlistForResultDto> RetrieveById(long Id)
    {
        throw new NotImplementedException();
    }
}
