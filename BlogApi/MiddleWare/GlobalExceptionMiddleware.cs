using Application.Exceptions;
using FluentValidation;

namespace BlogApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);        
            }
            catch (ValidationException ex)   
            {
                context.Response.StatusCode = 422;
                var errors = ex.Errors.Select(e => new
                {
                    error = e.ErrorMessage,
                    property = e.PropertyName
                });
                await context.Response.WriteAsJsonAsync(errors);
            }
            catch (UnAuthorizedUseCaseException ex)   
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });
            }
            catch(NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new
                {
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new { message = "There has been unexpected error" });
            }
        }
    }
}