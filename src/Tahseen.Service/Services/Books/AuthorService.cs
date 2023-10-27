using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Books.Author;
using Tahseen.Service.DTOs.Books.Book;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Helpers;
using Tahseen.Service.Interfaces.IBookServices;
using static System.Net.WebRequestMethods;

namespace Tahseen.Service.Services.Books;

public class AuthorService : IAuthorService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Author> _repository;

    public AuthorService(IMapper mapper, IRepository<Author> repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

    public async Task<AuthorForResultDto> AddAsync(AuthorForCreationDto dto)
    {
        var check = await this._repository.SelectAll()
            .Where(a => a.FirstName == dto.FirstName && a.LastName == dto.LastName && a.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (check != null)
        {
            throw new TahseenException(409, "This Author already exists.");
        }

        var wwwRootPath = Path.Combine(WebEnvironmentHost.WebRootPath, "Assets", "AuthorImages");
        var imageFolderPath = Path.GetDirectoryName(wwwRootPath);

        if (!Directory.Exists(imageFolderPath))
        {
            Directory.CreateDirectory(imageFolderPath);
        }

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.AuthorImage.FileName);
        var fullPath = Path.Combine(wwwRootPath, fileName);

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await dto.AuthorImage.CopyToAsync(stream);
            await stream.FlushAsync();
            stream.Close();
        }

        /*        var author = _mapper.Map<Author>(dto);
                author.AuthorImage = Path.Combine("Assets", "AuthorImages", fileName);*/
        var author = new Author()
        {
            FirstName = dto.FirstName,
            AuthorImage = Path.Combine("Assets", "AuthorImages", fileName),
            Biography = dto.Biography,
            LastName = dto.LastName,
            Nationality = dto.Nationality,
        };
        var result = await _repository.CreateAsync(author);
        return _mapper.Map<AuthorForResultDto>(result);
    }


    public async Task<AuthorForResultDto> ModifyAsync(long id, AuthorForUpdateDto dto)
    {
        var author = await _repository.SelectAll().Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefaultAsync();
        if (author is not null)
        {
            var mappedAuthor = _mapper.Map<Author>(dto);
            var result = await _repository.UpdateAsync(mappedAuthor);
            result.UpdatedAt = DateTime.UtcNow;
            return _mapper.Map<AuthorForResultDto>(result);
        }
        throw new Exception("Author not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AuthorForResultDto>> RetrieveAllAsync()
    {
        var results = this._repository.SelectAll().Where(a=>!a.IsDeleted);
        return _mapper.Map<IEnumerable<AuthorForResultDto>>(results);
    }

    public async Task<AuthorForResultDto> RetrieveByIdAsync(long id)
    {
        var author = await _repository.SelectByIdAsync(id);
        if (author is not null && !author.IsDeleted)
        {
            author.AuthorImage = $"https://localhost:7020/{author.AuthorImage.Replace('\\', '/').TrimStart('/')}";
            return _mapper.Map<AuthorForResultDto>(author);
        }

        throw new TahseenException(404, "Author not found");
    }


}