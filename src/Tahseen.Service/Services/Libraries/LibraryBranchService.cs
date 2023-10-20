using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.Library;
using Tahseen.Service.DTOs.Libraries.LibraryBranch;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.ILibrariesService;

namespace Tahseen.Service.Services.Libraries;

public class LibraryBranchService : ILibraryBranchService
{
    private readonly IMapper mapper;
    private readonly IRepository<LibraryBranch> repository;
    public LibraryBranchService(IMapper mapper, IRepository<LibraryBranch> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<LibraryBranchForResultDto> AddAsync(LibraryBranchForCreationDto dto)
    {
        var Check = await this.repository.SelectAll().Where(a => a.Name == dto.Name && a.Address == dto.Address && a.IsDeleted == false).FirstOrDefaultAsync();
        if (Check != null)
        {
            throw new TahseenException(409, "This LibraryBranch is exist");
        }
        var mappedLibraryBranch = this.mapper.Map<LibraryBranch>(dto);
        var result = await this.repository.CreateAsync(mappedLibraryBranch);
        
        return this.mapper.Map<LibraryBranchForResultDto>(result);
    }

    public async Task<LibraryBranchForResultDto> ModifyAsync(long id, LibraryBranchForUpdateDto dto)
    {
        var libraryBranch = await this.repository.SelectAll().Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefaultAsync();
        if (libraryBranch == null)
            throw new TahseenException(404, "LibraryBranch not found");

        var mappedLibraryBranch = mapper.Map(dto,libraryBranch);
        mappedLibraryBranch.UpdatedAt = DateTime.UtcNow;
        var result = await this.repository.UpdateAsync(mappedLibraryBranch);

        return this.mapper.Map<LibraryBranchForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var libraryBranch = await this.repository.SelectAll().Where(a => a.Id == id && a.IsDeleted == false).FirstOrDefaultAsync();
        if (libraryBranch == null)
            throw new TahseenException(404, "LibraryBranch not found");

        return await this.repository.DeleteAsync(libraryBranch.Id);
    }

    public async Task<IQueryable<LibraryBranchForResultDto>> RetrieveAllAsync()
    {
        var results = this.repository.SelectAll().Where(l => !l.IsDeleted);
        return mapper.Map<IQueryable<LibraryBranchForResultDto>>(results);
    }

    public async Task<LibraryBranchForResultDto> RetrieveByIdAsync(long id)
    {
        var libraryBranch = await this.repository.SelectByIdAsync(id);
        if (libraryBranch == null || libraryBranch.IsDeleted)
            throw new TahseenException(404, "LibraryBranch not found");

        return mapper.Map<LibraryBranchForResultDto>(libraryBranch);
    }
}
