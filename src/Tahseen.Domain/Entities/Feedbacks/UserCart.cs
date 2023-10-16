using Tahseen.Domain.Commons;
using Tahseen.Domain.Entities.Feedback;

namespace Tahseen.Domain.Entities.Feedbacks;

public class UserCart:Auditable
{
    public long UserId { get; set; }
    public ICollection<WishList> WishList { get; set; }
}
