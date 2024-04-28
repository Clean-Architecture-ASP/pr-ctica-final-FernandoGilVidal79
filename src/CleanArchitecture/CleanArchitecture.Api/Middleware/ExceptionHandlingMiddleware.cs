
using System.Security.Cryptography;
using CleanArchitecture.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static CleanArchitecture.Api.Middleware.ExceptionHandlingMiddleware;

namespace CleanArchitecture.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> looger)
    {
        _next = next;
        _logger = looger;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);

        }

        catch(Exception exception)
        {
            _logger.LogError(exception, "Ocurrio una excepción {message}", exception.Message);
            var exceptionDetails = GetExceptionDetails(exception);
            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.type,
                Title = exceptionDetails.title,
                Detail = exceptionDetails.detail

            };

            if (exceptionDetails.errors is not null)
            {
                problemDetails.Extensions["errors"] = exceptionDetails.errors;
            }

            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails  GetExceptionDetails(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "ValidationFailure",
                    "Error de Validación",
                    "Han ocurrido errores de validación",
                    validationException.Errors
                    ),
                _ => new ExceptionDetails(StatusCodes.Status500InternalServerError,
                "ServerError",
                "Error de servidor",
                "Un error inesperado ha ocurrido",
                null)
        };
    }

    internal record ExceptionDetails( int Status, string type, string title, string detail, IEnumerable<object>? errors);
}