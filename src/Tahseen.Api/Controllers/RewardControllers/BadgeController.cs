using Microsoft.AspNetCore.Mvc;
using Tahseen.Api.Models;
using Tahseen.Service.DTOs.Rewards.Badge;
using Tahseen.Service.Interfaces.IRewardsService;

namespace Tahseen.Api.Controllers.RewardControllers;

[ApiController]
[Route("api[controller]")]
public class BadgeController : ControllerBase
{
    private readonly IBadgeService _badgeService;

    public BadgeController(IBadgeService badgeService)
    {
        _badgeService = badgeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = _badgeService.RetrieveAll()
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
            Data = await _badgeService.RetrieveByIdAsync(Id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(BadgeForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _badgeService.AddAsync(dto)
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
            Data = await _badgeService.RemoveAsync(Id)
        };
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(long Id, BadgeForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await _badgeService.ModifyAsync(Id, dto)
        };
        return Ok(response);
    }
}