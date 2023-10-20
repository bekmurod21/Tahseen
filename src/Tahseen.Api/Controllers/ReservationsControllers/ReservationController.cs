using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.Reservations;
using Tahseen.Service.Interfaces.IReservationsServices;

namespace Tahseen.Api.Controllers.ReservationsControllers;

[ApiController]
[Route("api[controller]")]
public class ReservationController:ControllerBase
{
    private readonly IReservationsService _reservationService;
    public ReservationController(IReservationsService reservationService)
    {
        _reservationService =reservationService;
    }
    
          [HttpPost]
          public async Task<IActionResult> PostAsync(ReservationForCreationDto data)
          {
              var response = new Response()
              {
                  StatusCode = 200,
                  Message = "Success",
                  Data = await _reservationService.AddAsync(data)
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
                  Data = await _reservationService.RetrieveByIdAsync(Id)
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
                  Data = await _reservationService.RemoveAsync(Id)
              };
              return Ok(response);
          }
  
          [HttpPut]
          public async Task<IActionResult> PutAsync(long Id, ReservationForUpdateDto data)
          {
              var response = new Response()
              {
                  StatusCode = 200,
                  Message = "Success",
                  Data = await _reservationService.ModifyAsync(Id, data)
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
                  Data = _reservationService.RetrieveAllAsync()
              };
              return Ok(response);
          }
    
}