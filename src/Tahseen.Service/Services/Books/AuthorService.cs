using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Books;
using Tahseen.Service.DTOs.Books.Author;
using Tahseen.Service.DTOs.Books.Book;

namespace Tahseen.Service.Services.Books;

public class AuthorService
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
        var author = _mapper.Map<Author>(dto);
        var result= await _repository.CreateAsync(author);
        return _mapper.Map<AuthorForResultDto>(result);
    }

    public async Task<AuthorForResultDto> ModifyAsync(long id, AuthorForUpdateDto dto)
    {
        var author = await _repository.SelectByIdAsync(id);
        if (author is not null && !author.IsDeleted)
        {
            var mappedAuthor = _mapper.Map<Author>(dto);
            var result = await _repository.UpdateAsync(mappedAuthor);
            return _mapper.Map<AuthorForResultDto>(result);
        }
        throw new Exception("Author not found");
    }

    public async Task<bool> RemoveAsync(long id)
    {
        return await _repository.DeleteAsync(id);
    }

    public async ValueTask<AuthorForResultDto> RetrieveByIdAsync(long id)
    {
        var author = await _repository.SelectByIdAsync(id);
        if (author is not null && !author.IsDeleted)
            return _mapper.Map<AuthorForResultDto>(author);
        
        throw new Exception("Author  not found");
    }
}