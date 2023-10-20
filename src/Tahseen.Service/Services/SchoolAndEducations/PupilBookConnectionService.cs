using AutoMapper;
using Tahseen.Data.IRepositories;
using Tahseen.Domain.Entities.SchoolAndEducations;
using Tahseen.Service.DTOs.SchoolAndEducations;
using Tahseen.Service.Exceptions;
using Tahseen.Service.Interfaces.ISchoolAndEducation;

namespace Tahseen.Service.Services.SchoolAndEducations;

public class PupilBookConnectionService:IPupilBookConnectionService
{
    private readonly IMapper _mapper;
    private readonly IRepository<PupilBookConnection> _repository;

    public PupilBookConnectionService(IMapper mapper, IRepository<PupilBookConnection>repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<PupilBookConnectionForResultDto> AddAsync(PupilBookConnectionForCreationDto dto)
    {
        var mapped = _mapper.Map<PupilBookConnection>(dto);
        var result = _repository.CreateAsync(mapped);
        return _mapper.Map<PupilBookConnectionForResultDto>(result);
    }

    public async Task<PupilBookConnectionForResultDto> ModifyAsync(long id, PupilBookConnectionForUpdateDto dto)
    {
        var mapped = await _repository.SelectByIdAsync(id);
        if (mapped is null || mapped.IsDeleted)
        {
            throw new TahseenException(404, "PupilBookConnection is not found");
        }
        var updated = _mapper.Map(dto,mapped);
        updated.UpdatedAt = DateTime.UtcNow;
        var result = _repository.UpdateAsync(updated);
        return _mapper.Map<PupilBookConnectionForResultDto>(result);
    }

    public async Task<bool> RemoveAsync(long id)
        =>await _repository.DeleteAsync(id);

    public async Task<PupilBookConnectionForResultDto> RetrieveByIdAsync(long id)
    {
        var mapped = await _repository.SelectByIdAsync(id);
        if (mapped is null || mapped.IsDeleted)
        {
            throw new TahseenException(404, "PupilBookConnection is not found");
        }

        return _mapper.Map<PupilBookConnectionForResultDto>(mapped);
    }

    public async Task<IQueryable<PupilBookConnectionForResultDto>> RetrieveAllAsync()
    {
        var mapped = _repository.SelectAll().Where(x => !x.IsDeleted);
        return _mapper.Map<IQueryable<PupilBookConnectionForResultDto>>(mapped);
    }
}