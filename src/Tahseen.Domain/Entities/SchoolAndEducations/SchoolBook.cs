using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.SchoolAndEducations;

public class SchoolBook:Auditable
{
    public string Subject { get; set; }
    public long LibraryCode { get; set; }
}
