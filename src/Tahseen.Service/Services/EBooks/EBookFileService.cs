using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.EBooks;
using Tahseen.Service.DTOs.EBooks.EBookFile;
using Tahseen.Service.DTOs.FileUpload;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.IEBookServices;
using Tahseen.Service.Interfaces.IFileUploadService;

namespace Tahseen.Service.Services.EBooks;

public class EBookFileService : IEBookFileService
{
    private readonly IMapper _mapper;
    private readonly IRepository<EBookFile> _repository;
    private readonly IRepository<EBook> _eBookRepository;
    private readonly IFileUploadService _fileUploadService;

    public EBookFileService(
        IMapper mapper,
        IRepository<EBookFile> repository,
        IRepository<EBook> eBookRepository,
        IFileUploadService fileUploadService)
    {
        _mapper = mapper;
        _repository = repository;
        _eBookRepository = eBookRepository;
        _fileUploadService = fileUploadService;
    }
    public async Task<EBookFileForResultDto> AddAsync(EBookFileForCreationDto dto)
    {
        var eBook = await _eBookRepository.SelectAll()
            .Where(e => e.Id == dto.EBookId && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBook is null)
            throw new TahseenException(404, "EBook is not found");

        var FileUploadForCreation = new FileUploadForCreationDto
        {
            FolderPath = "EBookFiles",
            FormFile = dto.FilePath,
        };
        var FileResult = await this._fileUploadService.FileUploadAsync(FileUploadForCreation);

        var mapped = _mapper.Map<EBookFile>(dto);
        mapped.FilePath = Path.Combine("Assets", $"{FileResult.FolderPath}", FileResult.FileName);

        var result = await _repository.CreateAsync(mapped);

        return _mapper.Map<EBookFileForResultDto>(result);
    }

    public async Task<EBookFileForResultDto> ModifyAsync(long id, EBookFileForUpdateDto dto)
    {
        var eBook = await _eBookRepository.SelectAll()
            .Where(e => e.Id == dto.EBookId && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBook is null)
            throw new TahseenException(404, "EBook is not found");

        var eBookFile = await _repository.SelectAll()
            .Where(e => e.Id == id && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBookFile is null)
            throw new TahseenException(404, "EBookFile is not found");

        await _fileUploadService.FileDeleteAsync(eBookFile.FilePath);

        var FileUploadForCreation = new FileUploadForCreationDto
        {
            FolderPath = "EBookFiles",
            FormFile = dto.FilePath,
        };
        var FileResult = await this._fileUploadService.FileUploadAsync(FileUploadForCreation);

        var mapped = _mapper.Map(dto, eBookFile);
        mapped.UpdatedAt = DateTime.UtcNow;
        mapped.FilePath = Path.Combine("Assets", $"{FileResult.FolderPath}", FileResult.FileName);

        var result = await _repository.UpdateAsync(mapped);

        return _mapper.Map<EBookFileForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var eBookFile = await _repository.SelectAll()
            .Where(e => e.Id == id && e.IsDeleted == false)
            .FirstOrDefaultAsync();

        if (eBookFile is null)
            throw new TahseenException(404, "EBookFile is not found");

        await _fileUploadService.FileDeleteAsync(eBookFile.FilePath);

        return await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<EBookFileForResultDto>> RetrieveAllAsync()
    {
        var results = await this._repository.SelectAll()
                    .Where(e => !e.IsDeleted)
                    .Include(e => e.EBook)
                    .AsNoTracking()
                    .ToListAsync();

        foreach (var result in results)
        {
            result.FilePath = $"https://localhost:7020/{result.FilePath.Replace('\\', '/').TrimStart('/')}";
        }
        return _mapper.Map<IEnumerable<EBookFileForResultDto>>(results);
    }

    public async Task<EBookFileForResultDto> RetrieveByIdAsync(long id)
    {
        var eBookFile = await _repository.SelectAll()
            .Where(e => e.Id == id && e.IsDeleted == false)
            .Include(e => e.EBook)
            .FirstOrDefaultAsync();

        if (eBookFile is null)
            throw new TahseenException(404, "EBookFile is not found");

        eBookFile.FilePath = $"https://localhost:7020/{eBookFile.FilePath.Replace('\\', '/').TrimStart('/')}";

        return _mapper.Map<EBookFileForResultDto>(eBookFile);
    }
}
