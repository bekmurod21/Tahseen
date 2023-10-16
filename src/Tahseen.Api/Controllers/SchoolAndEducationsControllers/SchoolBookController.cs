using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.SchoolAndEducations;
using Tahseen.Service.Interfaces.ISchoolAndEducation;
using Tahseen.Service.Services.SchoolAndEducations;

namespace Tahseen.Api.Controllers.SchoolAndEducationsControllers;

public class SchoolBookController : ControllerBase
{
    private readonly ISchoolBookService _schoolBookService;

    public SchoolBookController(ISchoolBookService schoolBookService)
    {
        _schoolBookService = schoolBookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = _schoolBookService.RetrieveAll()
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
            Data = await _schoolBookService.RetrieveByIdAsync(Id)
        };
        return Ok(response);
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync(SchoolBookForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _schoolBookService.AddAsync(dto)
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
            Data = await _schoolBookService.RemoveAsync(id)
        };
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(long id, SchoolBookForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _schoolBookService.ModifyAsync(id, dto)
        };
        return Ok(response);
    }
}
