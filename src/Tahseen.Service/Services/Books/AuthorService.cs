using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Books.Author;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Helpers;
using Tahseen.Service.Interfaces.IBookServices;
using File = System.IO.File;

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
            .Where(a => a.FirstName == dto.FirstName && a.LastName == dto.LastName && !a.IsDeleted)
            .FirstOrDefaultAsync();

        if (check != null)
            throw new TahseenException(409, "This Author already exists.");

        var WwwRootPath = Path.Combine(WebEnvironmentHost.WebRootPath, "Assets", "AuthorImages");

        var assetsFolderPath = Path.Combine(WwwRootPath, "Assets");
        var authorImagesFolderPath = Path.Combine(assetsFolderPath, "AuthorImages");

        if (!Directory.Exists(assetsFolderPath))
        {
            Directory.CreateDirectory(assetsFolderPath);
        }

        if (!Directory.Exists(authorImagesFolderPath))
        {
            Directory.CreateDirectory(authorImagesFolderPath);
        }

        var imageFolderPath = Path.GetDirectoryName(WwwRootPath);

        var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.AuthorImage.FileName);
        var fullPath = Path.Combine(WwwRootPath, fileName);

        // Asynchronous file write using threading
        using (var streamFile = File.OpenWrite(fullPath))
        {
            await dto.AuthorImage.CopyToAsync(streamFile);
        }

        var author = new Author()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Biography = dto.Biography,
            Nationality = dto.Nationality,
            AuthorImage = Path.Combine("Assets", "AuthorImages", fileName),

        };
        var result = await _repository.CreateAsync(author);
        return _mapper.Map<AuthorForResultDto>(result);
    }

    public async Task<AuthorForResultDto> ModifyAsync(long id, AuthorForUpdateDto dto)
    {
        var author = await _repository.SelectAll().Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefaultAsync();
        if (author is not null)
        {

            var DeletePath = Path.Combine(WebEnvironmentHost.WebRootPath, author.AuthorImage);
            File.Delete(DeletePath);
            var WwwRootPath = Path.Combine(WebEnvironmentHost.WebRootPath, "Assets", "AuthorImages");
            var FileName = Guid.NewGuid().ToString("N") + Path.GetExtension(dto.AuthorImage.FileName);

            var FullPath = Path.Combine(WwwRootPath, FileName);

            using (var streamFile = File.OpenWrite(FullPath))
            {
                await dto.AuthorImage.CopyToAsync(streamFile);
            }
            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            author.Nationality = dto.Nationality;
            author.Biography = dto.Biography;
            author.AuthorImage = Path.Combine("Assets", "AuthorImages", FileName);
            author.UpdatedAt = DateTime.UtcNow;

            var result = await _repository.UpdateAsync(author);
            return _mapper.Map<AuthorForResultDto>(result);
        }
        throw new Exception("Author not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var results = await this._repository.SelectAll().Where(a => a.Id == id && !a.IsDeleted).FirstOrDefaultAsync();
        var FullPath = Path.Combine(WebEnvironmentHost.WebRootPath, results.AuthorImage);
        File.Delete(FullPath);
        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AuthorForResultDto>> RetrieveAllAsync()
    {
        var results = this._repository.SelectAll().Where(a => !a.IsDeleted);
        foreach (var result in results)
        {
            result.AuthorImage = $"https://localhost:7020/{result.AuthorImage.Replace('\\', '/').TrimStart('/')}";
        }
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