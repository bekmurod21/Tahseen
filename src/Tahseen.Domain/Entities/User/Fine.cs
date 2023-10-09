using Tahseen.Domain.Commons;
using Tahseen.Domain.Enums;

namespace Tahseen.Domain.Entities;

public class Fine:Auditable
{
    public long UserId { get; set; }
    public decimal Amount { get; set; }
    public string Reason { get; set; }
    public FineStatus Status { get; set; }
}