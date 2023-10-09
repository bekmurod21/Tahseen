using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.Book;

public class Publisher:Auditable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactInformation { get; set; }
}
