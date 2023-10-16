using Tahseen.Service.DTOs.Books.Author;

namespace Tahseen.Service.Interfaces.IBookServices;

public interface IAuthorService
{
    Task<AuthorForResultDto> AddAsync(AuthorForCreationDto dto);
    Task<AuthorForResultDto> ModifyAsync(AuthorForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<AuthorForResultDto> RetrieveByIdAsync(long id);
    IQueryable<AuthorForResultDto> RetrieveAll();
}