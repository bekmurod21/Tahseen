using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.Libraries.LibraryBranch;
using Tahseen.Service.Interfaces.ILibrariesService;
using Tahseen.Service.Services.Libraries;

namespace Tahseen.Api.Controllers.LibrariesControllers;

[ApiController]
[Route("api[controller]")]
public class LibraryBranchController:ControllerBase
{
    private readonly ILibraryBranchService _libraryBranchService;
    
    public LibraryBranchController(LibraryBranchService libraryBranchService)
    {
        _libraryBranchService =libraryBranchService;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync(LibraryBranchForCreationDto data)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _libraryBranchService.AddAsync(data)
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
            Data = await _libraryBranchService.RetrieveByIdAsync(Id)
        };
        return Ok(response);
    }
          
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(long Id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _libraryBranchService.RemoveAsync(Id)
        };
        return Ok(response);
    }
  
    [HttpPut]
    public async Task<IActionResult> PutAsync(long Id, LibraryBranchForUpdateDto data)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _libraryBranchService.ModifyAsync(Id, data)
        };
        return Ok(response);
    }
          
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = _libraryBranchService.RetrieveAll()
        };
        return Ok(response);
    }
    
}