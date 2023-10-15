using AutoMapper;
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

    async Task<LibraryBranchForResultDto> ILibraryBranchService.AddAsync(LibraryBranchForCreationDto dto)
    {
        var mappedLibraryBranch = this.mapper.Map<LibraryBranch>(dto);
        var result = await this.repository.CreateAsync(mappedLibraryBranch);
        
        return this.mapper.Map<LibraryBranchForResultDto>(result);
    }

    async Task<LibraryBranchForResultDto> ILibraryBranchService.ModifyAsync(LibraryBranchForUpdateDto dto)
    {
        var libraryBranch = await this.repository.SelectByIdAsync(dto.Id);
        if (libraryBranch == null || libraryBranch.IsDeleted)
            throw new TahseenException(404, "LibraryBranch not found");

        var mappedLibraryBranch = mapper.Map(dto,libraryBranch);
        mappedLibraryBranch.UpdatedAt = DateTime.UtcNow;
        var result = await this.repository.UpdateAsync(mappedLibraryBranch);

        return this.mapper.Map<LibraryBranchForResultDto>(result);
    }

    async Task<bool> ILibraryBranchService.RemoveAsync(long id)
    {
        var libraryBranch = await this.repository.SelectByIdAsync(id);
        if (libraryBranch == null || libraryBranch.IsDeleted)
            throw new TahseenException(404, "LibraryBranch not found");

        return await this.repository.DeleteAsync(libraryBranch.Id);
    }

    IQueryable<LibraryBranchForResultDto> ILibraryBranchService.RetrieveAll()
    {
        var results = this.repository.SelectAll().Where(l => !l.IsDeleted);
        return mapper.Map<IQueryable<LibraryBranchForResultDto>>(results);
    }

    async ValueTask<LibraryBranchForResultDto> ILibraryBranchService.RetrieveByIdAsync(long id)
    {
        var libraryBranch = await this.repository.SelectByIdAsync(id);
        if (libraryBranch == null || libraryBranch.IsDeleted)
            throw new TahseenException(404, "LibraryBranch not found");

        return mapper.Map<LibraryBranchForResultDto>(libraryBranch);
    }
}
