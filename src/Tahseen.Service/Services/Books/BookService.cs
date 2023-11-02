using Tahseen.Service.DTOs.Books.Book;
using Tahseen.Service.Interfaces.IBookServices;
using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Tahseen.Service.Interfaces.IFileUploadService;
using Tahseen.Service.Exceptions;
using Tahseen.Service.DTOs.FileUpload;

namespace Tahseen.Service.Services.Books;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Book> _repository;
    private readonly IFileUploadService _fileUploadService;

    public BookService(IMapper mapper, IRepository<Book> repository, IFileUploadService fileUploadService)
    {
        this._mapper = mapper;
        this._repository = repository;
        this._fileUploadService = fileUploadService;
    }

    public async Task<BookForResultDto> AddAsync(BookForCreationDto dto)
    {
        var book = await this._repository.SelectAll()
            .Where(b => b.Title.ToLower() == dto.Title.ToLower() && b.IsDeleted == false)
            .FirstOrDefaultAsync();
        if (book is not null)
            throw new TahseenException(404, "Book is not found");

        var FileUploadForCreation = new FileUploadForCreationDto
        {
            FolderPath = "BooksAssets",
            FormFile = dto.BookImage,
        };
        var FileResult = await this._fileUploadService.FileUploadAsync(FileUploadForCreation);

        var mapped = this._mapper.Map<Book>(dto);
        mapped.BookImage = Path.Combine("Assets", $"{FileResult.FolderPath}", FileResult.FileName);
        var result = await _repository.CreateAsync(mapped);
        return _mapper.Map<BookForResultDto>(result);
    }


    /// <summary>
    /// Do logic for user Student Pupil
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<BookForResultDto>> RetrieveAllAsync()
    {
        var books = this._repository.SelectAll().Where(e => e.IsDeleted == false);
        foreach (var book in books)
        {
            book.BookImage = $"https://localhost:7020/{book.BookImage.Replace('\\', '/').TrimStart('/')}";
        }
        return this._mapper.Map<IEnumerable<BookForResultDto>>(books);
    }

    public async Task<BookForResultDto> ModifyAsync(long id, BookForUpdateDto dto)
    {
        var book = await _repository.SelectAll().Where(a => a.Id == id && a.IsDeleted == false)
            .FirstOrDefaultAsync();
        if (book is null)
            throw new Exception("Book not found");

        // delete image
        await _fileUploadService.FileDeleteAsync(book.BookImage);

        // uploading image
        var FileUploadForCreation = new FileUploadForCreationDto
        {
            FolderPath = "BooksAssets",
            FormFile = dto.BookImage,
        };
        var FileResult = await this._fileUploadService.FileUploadAsync(FileUploadForCreation);

        var mappedBook = _mapper.Map(dto, book);
        mappedBook.UpdatedAt = DateTime.UtcNow;
        mappedBook.BookImage = Path.Combine("Assets", $"{FileResult.FolderPath}", FileResult.FileName);
        await _repository.UpdateAsync(mappedBook);
        return _mapper.Map<BookForResultDto>(mappedBook);
        
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var book = await this._repository.SelectAll()
            .Where(b => b.Id == id && !b.IsDeleted)
            .FirstOrDefaultAsync();
        if (book is null) 
            throw new TahseenException(404, "Book is not found");

        await _fileUploadService.FileDeleteAsync(book.BookImage);
        return await _repository.DeleteAsync(id);
    }

    public async Task<BookForResultDto> RetrieveByIdAsync(long id)
    {
        var book = await _repository.SelectByIdAsync(id);
        if (book is not null && !book.IsDeleted)
        {
            book.BookImage = $"https://localhost:7020/{book.BookImage.Replace('\\', '/').TrimStart('/')}";
            return _mapper.Map<BookForResultDto>(book);
        }
        
        throw new TahseenException(404,"Book does not found");
    }
}