using Tahseen.Service.DTOs.Libraries.LibraryBranch;

namespace Tahseen.Service.Interfaces.ILibrariesService;

public interface ILibraryBranchService
{
    Task<LibraryBranchForResultDto> AddAsync(LibraryBranchForCreationDto dto);
    Task<LibraryBranchForResultDto> ModifyAsync(long id, LibraryBranchForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<LibraryBranchForResultDto> RetrieveByIdAsync(long id);
    IQueryable<LibraryBranchForResultDto> RetrieveAll();
}
