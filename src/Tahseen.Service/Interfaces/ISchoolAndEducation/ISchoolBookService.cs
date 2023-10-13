using Tahseen.Service.DTOs.SchoolAndEducations;

namespace Tahseen.Service.Interfaces.ISchoolAndEducation;

public interface ISchoolBookService
{
    Task<SchoolBookForResultDto> AddAsync(SchoolBookForCreationDto dto);
    Task<SchoolBookForResultDto> ModifyAsync(long id, SchoolBookForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<SchoolBookForResultDto> RetrieveByIdAsync(long id);
    IQueryable<SchoolBookForResultDto> RetrieveAll();
}