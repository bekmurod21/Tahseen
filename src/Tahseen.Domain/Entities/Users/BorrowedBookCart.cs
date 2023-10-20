using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Users
{
    public class BorrowedBookCart : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<BorrowedBook> BorrowedBook { get; set;}
    }
}
