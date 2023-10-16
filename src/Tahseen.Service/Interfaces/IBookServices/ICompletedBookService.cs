using Tahseen.Service.DTOs.Books.CompletedBooks;

namespace Tahseen.Service.Interfaces.IBookServices;

public interface ICompletedBookService
{
    Task<CompletedBookForResultDto> AddAsync(CompletedBookForCreationDto dto);
    Task<CompletedBookForResultDto> ModifyAsync(CompletedBookForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<CompletedBookForResultDto> RetrieveByIdAsync(long id);
    IQueryable<CompletedBookForResultDto> RetrieveAll();
}
