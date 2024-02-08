using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon.Runtime.Internal;
using TodoApi.Shared.DTOs;
using TodoApi.Shared.Exceptions;

namespace TodoApi.Shared.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    
    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException exception)
        {
            var response = context.Response;
            response.StatusCode = StatusCodes.Status404NotFound;
            response.ContentType = "application/json";
            
            var errorResponse = new ExceptionResponseDTO()
            {
                Message = exception.ErrorMessage,
                ErrorCode = exception.ErrorCode
            };

            await response.WriteAsync(JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }));
        }
    }
}