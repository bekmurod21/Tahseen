using Tahseen.Service.DTOs.SchoolAndEducations;

namespace Tahseen.Service.Interfaces.ISchoolAndEducation;

public interface IPupilService
{
    Task<PupilForResultDto> AddAsync(PupilForCreationDto dto);
    Task<PupilForResultDto> ModifyAsync(long id, PupilForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<PupilForResultDto> RetrieveByIdAsync(long id);
    IQueryable<PupilForResultDto> RetrieveAll();
}