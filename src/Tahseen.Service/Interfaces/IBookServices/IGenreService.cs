using Tahseen.Service.DTOs.Books.Genre;

namespace Tahseen.Service.Interfaces.IBookServices;

public interface IGenreService
{
    public Task<GenreForResultDto> AddAsync(GenreForCreationDto dto);
    public Task<GenreForResultDto> ModifyAsync(long id, GenreForUpdateDto dto);
    public Task<bool> RemoveAsync(long id);
    public ValueTask<GenreForResultDto> RetrieveByIdAsync(long id);
    public ICollection<GenreForResultDto> RetrieveAll();    
}