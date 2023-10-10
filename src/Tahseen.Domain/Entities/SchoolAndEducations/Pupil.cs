using System;
using Tahseen.Domain.Commons;

namespace Tahseen.Domain.Entities.SchoolAndEducations;

public class Pupil:Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Grade { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<PupilBookConnection> SubjectBooksBorrow { get; set; }
    public string Image { get; set; }
    public long LibraryCode { get; set; }
}
