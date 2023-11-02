using Tahseen.Service.DTOs.Books.Book;
using Tahseen.Service.Interfaces.IBookServices;
using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Tahseen.Domain.Entities.Library;
using Tahseen.Service.Exceptions;

namespace Tahseen.Service.Services.Books;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Book> _repository;
    private readonly IRepository<LibraryBranch> _libraryRepository;

    public BookService(IMapper mapper, IRepository<Book> repository, IRepository<LibraryBranch> libraryRepository)
    {
        this._mapper = mapper;
        this._repository = repository;
        _libraryRepository = libraryRepository;
    }

    public async Task<BookForResultDto> AddAsync(BookForCreationDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        var result = await _repository.CreateAsync(book);
        return _mapper.Map<BookForResultDto>(result);
    }

    public async Task<IEnumerable<BookForResultDto>> RetrieveAllAsync(long? libraryBranchId)
    {
        var allLibraries = this._libraryRepository.SelectAll().Where(l => l.IsDeleted == false);

        if (libraryBranchId == null)
        {
            // User belongs to a public library - retrieve all public library books
            var publicLibraryIds = allLibraries.Where(l => l.LibraryType == Domain.Enums.LibraryType.Public)
                                              .Select(l => l.Id)
                                              .ToList();

            var publicLibraryBooks = this._repository.SelectAll()
                .Where(e => e.IsDeleted == false && publicLibraryIds.Contains(e.LibraryId));

            return this._mapper.Map<IEnumerable<BookForResultDto>>(publicLibraryBooks);
        }
        else
        {
            var library = await this._libraryRepository.SelectByIdAsync(libraryBranchId.Value);

            if (library == null || library.IsDeleted)
            {
                // Handle the case where the specified library branch does not exist or is deleted
                throw new TahseenException(404, "Library branch not found");
            }

            var books = this._repository.SelectAll()
                .Where(e => e.IsDeleted == false && e.LibraryId == libraryBranchId);

            return this._mapper.Map<IEnumerable<BookForResultDto>>(books);
        }
    }



    public async Task<BookForResultDto> ModifyAsync(long id, BookForUpdateDto dto)
    {
        var book = await _repository.SelectAll().Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefaultAsync();
        if (book is not null)
        {
            var mappedBook = _mapper.Map(dto, book);
            mappedBook.UpdatedAt = DateTime.UtcNow;
            var result = await _repository.UpdateAsync(mappedBook);
            return _mapper.Map<BookForResultDto>(result);
        }
        throw new Exception("Book not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async Task<BookForResultDto> RetrieveByIdAsync(long id)
    {
        var book = await _repository.SelectByIdAsync(id);
        if (book is not null && !book.IsDeleted)
            return _mapper.Map<BookForResultDto>(book);
        
        throw new Exception("Book does not found");
    }
}