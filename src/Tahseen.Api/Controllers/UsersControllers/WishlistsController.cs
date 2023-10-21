using Tahseen.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Tahseen.Service.DTOs.Users.Wishlists;
using Tahseen.Service.Interfaces.IUsersService;

namespace Tahseen.Api.Controllers.UsersControllers
{
    public class WishlistsController : BaseController
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
                Data = this._wishlistService.RetrieveAllAsync()
            });


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = await this._wishlistService.RemoveAsync(id)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, WishlistForUpdateDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Successful",
                Data = await this._wishlistService.ModifyAsync(id,dto)
            });
    }
}
