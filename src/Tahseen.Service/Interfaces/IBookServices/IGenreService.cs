using Tahseen.Service.DTOs.Books.Genre;

namespace Tahseen.Service.Interfaces.IBookServices;

public interface IGenreService
{
    Task<GenreForResultDto> AddAsync(GenreForCreationDto dto);
    Task<GenreForResultDto> ModifyAsync(long id, GenreForUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    ValueTask<GenreForResultDto> RetrieveByIdAsync(long id);
}