using Tahseen.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Tahseen.Service.DTOs.Books.Book;
using Tahseen.Service.Interfaces.IBookServices;

namespace Tahseen.Api.Controllers.BooksControllers
{
    public class BooksController : BaseController
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]BookForCreationDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.AddAsync(dto)
            });

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute]long id,[FromBody]BookForUpdateDto dto) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.ModifyAsync(id, dto)
            });

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.RemoveAsync(id)
            });
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(new Response
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this.service.RetrieveAllAsync()
        });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]long id) =>
            Ok(new Response
            {
                StatusCode = 200,
                Message = "Success",
                Data = await this.service.RetrieveByIdAsync(id)
            });
    }
}
