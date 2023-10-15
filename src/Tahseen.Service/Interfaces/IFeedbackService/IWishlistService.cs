using Tahseen.Service.DTOs.Feedbacks.Wishlists;

namespace Tahseen.Service.Interfaces.IFeedbackService;

public interface IWishlistService
{
    Task<WishlistForResultDto> AddAsync(WishlistForCreationDto dto);
    Task<WishlistForResultDto> ModifyAsync(WishlistForUpdateDto dto);
    Task<bool> RemoveAsync(long Id);
    ValueTask<WishlistForResultDto> RetrieveById(long Id);
    IQueryable<WishlistForResultDto> RetrieveAll();
}
