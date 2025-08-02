using System.Diagnostics;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            var response = new FluentValidationException
            {
                Errors = validationException.Errors
                    .Select(e => e.ErrorMessage)
                    .ToList()
            };

            context.Result = new BadRequestObjectResult(response);
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
            return;
        }

        context.Result = new ObjectResult(new { error = "Erro Inersperado" })
        {
            StatusCode = 500
        };
        context.ExceptionHandled = true;
    }
}