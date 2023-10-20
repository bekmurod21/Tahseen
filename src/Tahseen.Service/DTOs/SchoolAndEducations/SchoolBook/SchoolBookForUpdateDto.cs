namespace Tahseen.Service.DTOs.SchoolAndEducations;

public class SchoolBookForUpdateDto
{
    public long Id { get; set; }
    public string SchoolBookTitle { get; set; }
    public string Grade { get; set; }
    public long LibraryBranchId { get; set; }
}