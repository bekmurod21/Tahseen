using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Feedback;

public class Feedback:Auditable
{
    public long  UserId { get; set; }
    public long  BookId { get; set; }
    public string Comment { get; set; }
    public decimal Rating { get; set; }
    public DateTime Date { get; set; }
}