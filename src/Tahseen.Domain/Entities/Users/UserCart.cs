using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Users;

public class UserCart : Auditable
{
    public long UserId { get; set; }
    public ICollection<WishList> WishList { get; set; }
}
