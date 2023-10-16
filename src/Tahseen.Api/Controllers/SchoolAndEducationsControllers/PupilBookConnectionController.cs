using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.SchoolAndEducations;
using Tahseen.Service.Interfaces.ISchoolAndEducation;

namespace Tahseen.Api.Controllers.SchoolAndEducationsControllers;


[ApiController]
[Route("api/[controller]/[action]")]
public class PupilBookConnectionController : ControllerBase
{
    private readonly IPupilBookConnectionService _pupilBookConnectionService;

    public PupilBookConnectionController(IPupilBookConnectionService pupilBookConnectionService)
    {
        _pupilBookConnectionService = pupilBookConnectionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = _pupilBookConnectionService.RetrieveAll()
        };
        return Ok(response);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilBookConnectionService.RetrieveByIdAsync(Id)
        };
        return Ok(response);
    }



    [HttpPost]
    public async Task<IActionResult> PostAsync(PupilBookConnectionForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilBookConnectionService.AddAsync(dto)
        };
        return Ok(response);
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilBookConnectionService.RemoveAsync(id)
        };
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(long id, PupilBookConnectionForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _pupilBookConnectionService.ModifyAsync(id, dto)
        };
        return Ok(response);
    }
}
