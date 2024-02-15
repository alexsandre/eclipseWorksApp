using EclipseWorksApp.API.Exceptions;
using EclipseWorksApp.API.Models;
using EclipseWorksApp.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EclipseWorksApp.API.Config
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomHTTPException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, ex.StatusCode);
            }
            catch (DomainException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, StatusCodes.Status500InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new CustomHttpResponse(null, message);
            var responseJson = JsonSerializer.Serialize(response);
            
            await context.Response.WriteAsync(responseJson);
        }
    }
}
