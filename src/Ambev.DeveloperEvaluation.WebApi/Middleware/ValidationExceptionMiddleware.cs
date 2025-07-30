using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.WebApi.Common;
using FluentValidation;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Middleware
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
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
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (NotFoundException) 
            {
                await HandleNotFoundExceptionExceptionAsync(context);
            }
            catch (UnauthorizedAccessException)
            {
                await HandleUnauthorizedAccessExceptionExceptionAsync(context);
            }
            catch (Exception)
            {
                await HandleExceptionExceptionAsync(context);
            }

        }

        private static Task HandleExceptionExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Internal Server Error"
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, JsonSerializerOptions.Default));
        }

        private static Task HandleNotFoundExceptionExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Not Found"
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, JsonSerializerOptions.Default));
        }

        private static Task HandleUnauthorizedAccessExceptionExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Wrong email or password"
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, JsonSerializerOptions.Default));
        }

        private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var response = new ApiResponse
            {
                Success = false,
                Message = "Validation Failed",
                Errors = exception.Errors
                    .Select(error => (ValidationErrorDetail)error)
            };

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response, jsonOptions));
        }
    }
}
