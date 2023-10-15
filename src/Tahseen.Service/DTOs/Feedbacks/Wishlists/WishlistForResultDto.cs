using Tahseen.Domain.Enums;
using Tahseen.Service.DTOs.Users.User;

namespace Tahseen.Service.DTOs.Feedbacks.Wishlists;

public class WishlistForResultDto
{
    public long UserId { get; set; }
    public UserForResultDto User { get; set; }
    public long BookId { get; set; }
    //public BookForResultDto Book { get; set; }
    public WishListStatus Status { get; set; }
}
