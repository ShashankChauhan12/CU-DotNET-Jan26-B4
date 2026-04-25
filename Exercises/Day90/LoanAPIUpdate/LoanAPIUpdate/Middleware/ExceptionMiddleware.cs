using LoanAPIUpdate.Common;
using LoanAPIUpdate.Exceptions;
using System.Net;
using System.Text.Json;

namespace LoanAPIUpdate.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            if (ex is NotFoundException)
                code = HttpStatusCode.NotFound;

            else if (ex is BadRequestException)
                code = HttpStatusCode.BadRequest;

            context.Response.StatusCode = (int)code;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(
                ApiResponse<string>.Fail(ex.Message));

            await context.Response.WriteAsync(result);
        }
    }
}
