using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities;

public class BorrowedBook:Auditable
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public BorrowedBookStatus Status { get; set; }
    public decimal FineAmount { get; set; }
}