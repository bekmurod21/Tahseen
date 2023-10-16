using Tahseen.Service.DTOs.Librarians;

namespace Tahseen.Service.Interfaces.ILibrariansService;

public interface ILibrarianService
{
    Task<LibrarianForResultDto> AddAsync(LibrarianForCreationDto dto);
    Task<LibrarianForResultDto> ModifyAsync(LibrarianForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<LibrarianForResultDto> RetrieveById(long id);
    IQueryable<LibrarianForResultDto> RetrieveAll();
}
