using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.SchoolAndEducations;
using Tahseen.Service.DTOs.SchoolAndEducations;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.ISchoolAndEducation;

namespace Tahseen.Service.Services.SchoolAndEducations;

public class SchoolBookService:ISchoolBookService
{
    private readonly IMapper _mapper;
    private readonly IRepository<SchoolBook> _repository;

    public SchoolBookService(IMapper mapper, IRepository<SchoolBook>repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<SchoolBookForResultDto> AddAsync(SchoolBookForCreationDto dto)
    {
        var mapped = _mapper.Map<SchoolBook>(dto);
        var result = _repository.CreateAsync(mapped);
        return _mapper.Map<SchoolBookForResultDto>(result);
    }

    public async Task<SchoolBookForResultDto> ModifyAsync(long id, SchoolBookForUpdateDto dto)
    {
        var book =await _repository.SelectByIdAsync(id);
        if (book is null ||book.IsDeleted)
        {
            throw new TahseenException(404, "SchoolBooks not found");
        }

        var mapped = _mapper.Map(dto, book);
        mapped.UpdatedAt = DateTime.UtcNow;
        var result = _repository.UpdateAsync(mapped);
        return _mapper.Map<SchoolBookForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
        => await _repository.DeleteAsync(id);

    public async Task<SchoolBookForResultDto> RetrieveByIdAsync(long id)
    {
        var book =await _repository.SelectByIdAsync(id);
        if (book is null ||book.IsDeleted)
        {
            throw new TahseenException(404, "SchoolBooks not found");
        }
        return _mapper.Map<SchoolBookForResultDto>(book);
    }

    public async Task<IQueryable<SchoolBookForResultDto>> RetrieveAllAsync()
    {
        var books = _repository.SelectAll().Where(x => !x.IsDeleted);
        return _mapper.Map<IQueryable<SchoolBookForResultDto>>(books);
    }
}