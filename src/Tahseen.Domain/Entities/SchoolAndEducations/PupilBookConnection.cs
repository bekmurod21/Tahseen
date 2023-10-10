using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.SchoolAndEducations;

public class PupilBookConnection : Auditable
{
    public long PupilId { get; set; }
    public Pupil Pupil { get; set; }
    public long SchoolBookId { get; set; }
    public SchoolBook SchoolBook { get; set; }
    public long LibraryCode { get; set; }
}