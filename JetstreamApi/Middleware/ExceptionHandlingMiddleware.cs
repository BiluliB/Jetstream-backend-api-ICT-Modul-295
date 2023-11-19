using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        string message = exception.Message;
        int statusCode = (int)HttpStatusCode.InternalServerError;

        // Spezielle Behandlung für DbUpdateException
        if (exception is DbUpdateException dbUpdateException)
        {
            // Hier können Sie weitere Details aus der DbUpdateException extrahieren
            message = "Ein Datenbankfehler ist aufgetreten: " + dbUpdateException.InnerException?.Message;
            statusCode = (int)HttpStatusCode.BadRequest; // Oder einen anderen passenden Statuscode
        }

        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsJsonAsync(new
        {
            Message = message,
            StatusCode = statusCode
        });
    }
}
