using Tahseen.Api.Models;
using Tahseen.Service.Exceptions;

namespace Tahseen.Api.Middlewares
{
    public class ExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (TahseenException ex)
            {
                context.Response.StatusCode = ex.statusCode;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = ex.statusCode,
                    Message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response
                {
                    StatusCode = 500,
                    Message = ex.Message,
                });
            }
        }
    }
}
