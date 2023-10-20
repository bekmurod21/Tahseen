using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Users
{
    public class BorrowedBookCart : Auditable
    {
        public long UserId { get; set; }
        public IQueryable<BorrowedBook> BorrowedBook { get; set;}
    }
}
