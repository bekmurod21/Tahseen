using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.Notifications;
using Tahseen.Service.Interfaces.INotificationServices;

namespace Tahseen.Api.Controllers.NotificationsControllers;

[ApiController]
[Route("api[controller]")]
public class NotificationController:ControllerBase
{
    private readonly INotificationService _notificationService;
    public NotificationController(INotificationService notificationService)
    {
        _notificationService =notificationService;
    }
    
          [HttpPost]
          public async Task<IActionResult> PostAsync(NotificationForCreationDto data)
          {
              var response = new Response()
              {
                  StatusCode = 200,
                  Message = "Success",
                  Data = await _notificationService.AddAsync(data)
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
                  Data = await _notificationService.RetrieveByIdAsync(Id)
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
                  Data = await _notificationService.RemoveAsync(Id)
              };
              return Ok(response);
          }
  
          [HttpPut]
          public async Task<IActionResult> PutAsync(long Id, NotificationForUpdateDto data)
          {
              var response = new Response()
              {
                  StatusCode = 200,
                  Message = "Success",
                  Data = await _notificationService.ModifyAsync(Id, data)
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
                  Data = _notificationService.RetrieveAll()
              };
              return Ok(response);
          }
    
}