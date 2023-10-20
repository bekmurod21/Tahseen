using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Librarians;
using Tahseen.Service.DTOs.Librarians;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.ILibrariansService;

namespace Tahseen.Service.Services.Libraries;

public class LibrarianService : ILibrarianService
{
    private readonly IRepository<Librarian> repository;
    private readonly IMapper mapper;

    public LibrarianService(IRepository<Librarian> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<LibrarianForResultDto> AddAsync(LibrarianForCreationDto dto)
    {
        var mappedLibrarian = mapper.Map<Librarian>(dto);
        var result = await this.repository.CreateAsync(mappedLibrarian);
        return this.mapper.Map<LibrarianForResultDto>(result);
    }

    public async Task<LibrarianForResultDto> ModifyAsync(long id, LibrarianForUpdateDto dto)
    {
        var librarian = await this.repository.SelectByIdAsync(id);
        if (librarian == null || librarian.IsDeleted)
            throw new TahseenException(404, "Librarina not found");

        var mapped = this.mapper.Map(dto, librarian);
        mapped.UpdatedAt = DateTime.UtcNow;
        var result = await this.repository.UpdateAsync(mapped);

        return mapper.Map<LibrarianForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var librarian = await this.repository.SelectByIdAsync(id);
        if (librarian == null || librarian.IsDeleted)
            throw new TahseenException(404, "Lirarian not found");

        return await this.repository.DeleteAsync(librarian.Id);
    }

    public async Task<IQueryable<LibrarianForResultDto>> RetrieveAllAsync()
    {
        var librarians = this.repository.SelectAll().Where(l => !l.IsDeleted);
        return this.mapper.Map<IQueryable<LibrarianForResultDto>>(librarians);
    }

    public async Task<LibrarianForResultDto> RetrieveByIdAsync(long id)
    {
        var librarian = await this.repository.SelectByIdAsync(id);
        if (librarian is null || librarian.IsDeleted)
            throw new TahseenException(404, "Librarian not found");

        return this.mapper.Map<LibrarianForResultDto>(librarian);
    }
}
