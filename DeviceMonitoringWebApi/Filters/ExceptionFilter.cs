using DeviceMonitoringWebApi.Exceptions.Base;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DeviceMonitoringWebApi.Filters
{
    public class ExceptionFilter(ILogger<ExceptionFilter> logger) : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var httpContext = context.HttpContext;

            httpContext.Response.StatusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                InvalidFieldValueException => StatusCodes.Status400BadRequest,
                ConflictException => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

            logger.LogError(exception, "An error occurred while processing the request.");

            httpContext.Response.WriteAsJsonAsync(new
            {
                ActionName = context.ActionDescriptor.DisplayName,
                exception.Message,
                exception.StackTrace
            });

            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
