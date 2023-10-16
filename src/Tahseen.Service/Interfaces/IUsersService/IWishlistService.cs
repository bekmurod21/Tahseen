using Tahseen.Service.DTOs.Users.Wishlists;

namespace Tahseen.Service.Interfaces.IUsersService;

public interface IWishlistService
{
    Task<WishlistForResultDto> AddAsync(WishlistForCreationDto dto);
    Task<WishlistForResultDto> ModifyAsync(WishlistForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<WishlistForResultDto> RetrieveById(long id);
    IQueryable<WishlistForResultDto> RetrieveAll();
}
