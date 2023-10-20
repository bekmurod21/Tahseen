using Tahseen.Domain.Entities.Users;

namespace Tahseen.Service.DTOs.Users.UserCart
{
    public class UserCartForUpdateDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public IQueryable<WishList> WishList { get; set; }
    }
}
