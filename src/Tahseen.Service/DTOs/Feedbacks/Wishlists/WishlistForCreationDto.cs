using Tahseen.Domain.Enums;

namespace Tahseen.Service.DTOs.Feedbacks.Wishlists;
public class WishlistForCreationDto
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public WishListStatus Status { get; set; }
}
