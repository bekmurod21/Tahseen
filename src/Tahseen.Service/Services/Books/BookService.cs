using Tahseen.Service.DTOs.Books.Book;
using Tahseen.Service.Interfaces.IBookServices;
using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;

namespace Tahseen.Service.Services.Books;

public class BookService:IBookService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Book> _repository;

    public BookService(IMapper mapper, IRepository<Book> repository)
    {
        this._mapper = mapper;
        this._repository = repository;
    }

    public async Task<BookForResultDto> AddAsync(BookForCreationDto dto)
    {
        var book = _mapper.Map<Book>(dto);
        var result = await _repository.CreateAsync(book);
        return _mapper.Map<BookForResultDto>(result);
    }

    public async Task<BookForResultDto> ModifyAsync(long id, BookForUpdateDto dto)
    {
        var book = await _repository.SelectByIdAsync(id);
        if (book is not null && !book.IsDeleted)
        {
            var mappedBook = _mapper.Map<Book>(dto);
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

    public async ValueTask<BookForResultDto> RetrieveByIdAsync(long id)
    {
        var book = await _repository.SelectByIdAsync(id);
        if (book is not null && !book.IsDeleted)
            return _mapper.Map<BookForResultDto>(book);
        
        throw new Exception("Book does not found");
    }
}