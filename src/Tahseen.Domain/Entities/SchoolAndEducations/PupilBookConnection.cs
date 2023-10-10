using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.SchoolAndEducations;

public class PupilBookConnection:Auditable
{
    public long PupilId { get; set; }
    public long SchoolBookId { get; set; }
    public long LibraryCode { get; set; }
}