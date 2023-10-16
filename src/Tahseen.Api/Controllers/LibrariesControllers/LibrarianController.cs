using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.Librarians;
using Tahseen.Service.Interfaces.ILibrariansService;

namespace Tahseen.Api.Controllers.LibrariesControllers;

[ApiController]
[Route("api[controller]")]
public class LibrarianController:ControllerBase
{
    
    private readonly ILibrarianService _librarianService;
    
    public LibrarianController(ILibrarianService librarianService)
    {
        _librarianService =librarianService;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync(LibrarianForCreationDto data)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _librarianService.AddAsync(data)
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
            Data = await _librarianService.RetrieveByIdAsync(Id)
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
            Data = await _librarianService.RemoveAsync(Id)
        };
        return Ok(response);
    }
  
    [HttpPut]
    public async Task<IActionResult> PutAsync(long Id, LibrarianForUpdateDto data)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _librarianService.ModifyAsync(Id, data)
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
            Data = _librarianService.RetrieveAll()
        };
        return Ok(response);
    }
    
}
