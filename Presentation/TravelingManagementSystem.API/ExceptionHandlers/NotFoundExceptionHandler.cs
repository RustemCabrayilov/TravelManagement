using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelingManagementSystem.Persistence.Exceptions;

namespace TravelingManagementSystem.API.ExceptionHandlers;

public class NotFoundExceptionHandler( ILogger _logger):IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException notFoundException)
        {
            return false;
        }
        _logger.LogError(exception,"Exception occured:{Message}",exception.Message);
        var problemDetails = new ProblemDetails()
        {
        Status = StatusCodes.Status404NotFound,
        Title = "Not Found",
        Detail = exception.Message
        };
        httpContext.Response.StatusCode=problemDetails.Status.Value;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}