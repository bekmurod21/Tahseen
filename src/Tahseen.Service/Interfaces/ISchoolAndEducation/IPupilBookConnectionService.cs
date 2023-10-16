using Tahseen.Service.DTOs.Books.Author;
using Tahseen.Service.DTOs.SchoolAndEducations;

namespace Tahseen.Service.Interfaces.ISchoolAndEducation;

public interface IPupilBookConnectionService
{
    Task<PupilBookConnectionForResultDto> AddAsync(PupilBookConnectionForCreationDto dto);
    Task<PupilBookConnectionForResultDto> ModifyAsync(long id, PupilBookConnectionForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<PupilBookConnectionForResultDto> RetrieveByIdAsync(long id);
    IQueryable<PupilBookConnectionForResultDto> RetrieveAll();
}