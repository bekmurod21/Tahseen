using Tahseen.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Tahseen.Service.DTOs.Users.Wishlists;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Api.Controllers.UsersControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishlistsController : ControllerBase
    {
      
        private readonly IWishlistService _wishlistService;
        public WishlistsController(IWishlistService wishlistService)
        {
            this._wishlistService = wishlistService;
        }

        [HttpGet]
        public IQueryable<IActionResult> GetAll()
            => (IQueryable<IActionResult>)Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = this._wishlistService.RetrieveAll()
            });


        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = await this._wishlistService.RemoveAsync(id)
            });


        [HttpPost]
        public async Task<IActionResult> PostAsync(WishlistForCreationDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = await this._wishlistService.AddAsync(dto)
            });


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = await this._wishlistService.RemoveAsync(id)
            });

        [HttpPut]
        public async Task<IActionResult> PutAsync(WishlistForUpdateDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = await this._wishlistService.ModifyAsync(dto)
            });
    }
}
