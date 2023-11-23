using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Tahseen.Domain.Entities.EBooks;
using Tahseen.Service.Configurations;
using Tahseen.Service.DTOs.EBooks.EBook;
using Tahseen.Service.DTOs.FileUpload;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Extensions;
using Tahseen.Service.Interfaces.IEBookServices;
using Tahseen.Service.Interfaces.IFileUploadService;

namespace Tahseen.Service.Services.EBooks;

public class EBookService : IEBookService
{
    private readonly IMapper _mapper;
    private readonly IRepository<EBook> _repository;
    private readonly IRepository<Genre> _genreRepository;
    private readonly IRepository<Author> _authorRepository;
    private readonly IFileUploadService _fileUploadService;

    public EBookService(
        IMapper mapper,
        IRepository<EBook> repository,
        IRepository<Genre> genreRepository,
        IRepository<Author> authorRepository,
        IFileUploadService fileUploadService)
    {
        _mapper = mapper;
        _repository = repository;
        _genreRepository = genreRepository;
         _authorRepository = authorRepository;
        _fileUploadService = fileUploadService;
    }
    public async Task<EBookForResultDto> AddAsync(EBookForCreationDto dto)
    {
        var author = await _authorRepository.SelectAll()
            .Where(a => a.Id == dto.AuthorId && a.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (author is null)
            throw new TahseenException(404, "Author is not null");

        var genre = await _genreRepository.SelectAll()
            .Where(g => g.Id == dto.GenreId && g.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (genre is null)
            throw new TahseenException(404, "Genre is not null");

        var eBook = await _repository.SelectAll()
            .Where(e => e.AuthorId == dto.AuthorId &&
            e.GenreId == dto.GenreId && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBook is not null)
            throw new TahseenException(409, "EBook is already exist");

        var FileUploadForCreation = new FileUploadForCreationDto
        {
            FolderPath = "EBooksAssets",
            FormFile = dto.Image,
        };
        var FileResult = await this._fileUploadService.FileUploadAsync(FileUploadForCreation);

        var mapped = _mapper.Map<EBook>(dto);
        mapped.Image = Path.Combine("Assets", $"{FileResult.FolderPath}", FileResult.FileName);

        var result = await _repository.CreateAsync(mapped);

        return _mapper.Map<EBookForResultDto>(result);
    }

    public async Task<EBookForResultDto> ModifyAsync(long id, EBookForUpdateDto dto)
    {
        var author = await _authorRepository.SelectAll()
            .Where(a => a.Id == dto.AuthorId && a.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (author is null)
            throw new TahseenException(404, "Author is not null");

        var genre = await _genreRepository.SelectAll()
            .Where(g => g.Id == dto.GenreId && g.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (genre is null)
            throw new TahseenException(404, "Genre is not null");

        var eBook = await _repository.SelectAll()
            .Where(e => e.Id == id && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBook is null)
            throw new TahseenException(404, "EBook is not found");

        await _fileUploadService.FileDeleteAsync(eBook.Image);

        var FileUploadForCreation = new FileUploadForCreationDto
        {
            FolderPath = "EBooksAssets",
            FormFile = dto.Image,
        };
        var FileResult = await this._fileUploadService.FileUploadAsync(FileUploadForCreation);

        var mapped = _mapper.Map(dto, eBook);
        mapped.UpdatedAt = DateTime.UtcNow;
        mapped.Image = Path.Combine("Assets", $"{FileResult.FolderPath}", FileResult.FileName);

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<EBookForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var eBook = await _repository.SelectAll()
            .Where(e => e.Id == id && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBook is null)
            throw new TahseenException(404, "EBook is not found");

        await _fileUploadService.FileDeleteAsync(eBook.Image);

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<EBookForResultDto>> RetrieveAllAsync(PaginationParams @params)
    {
        var results = await this._repository.SelectAll()
            .Where(e => !e.IsDeleted)
            .ToPagedList(@params)
            .Include(a => a.Author)
            .Include(g => g.Genre)
            .AsNoTracking()
            .ToListAsync();

  
        return _mapper.Map<IEnumerable<EBookForResultDto>>(results);
    }

    public async Task<EBookForResultDto> RetrieveByIdAsync(long id)
    {
        var eBook = await _repository.SelectAll()
            .Where(e => e.Id == id && e.IsDeleted == false)
            .Include(a => a.Author)
            .Include(g => g.Genre)
            .FirstOrDefaultAsync();

        if (eBook is null)
            throw new TahseenException(404, "EBook is not found");


        return _mapper.Map<EBookForResultDto>(eBook);
    }
}
